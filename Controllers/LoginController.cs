using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;

namespace CommerceProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _db;



        //constructor
        public LoginController(ApplicationDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //IEnumerable<Login> objLoginList = _db.Logins;
            //return View(objLoginList);
            return View();
        }

        public IActionResult Test()
        {
            IEnumerable<User_1> users = _db.User_1s;
            return View("Demo");
        }

        public string NewUserCreated() {
            return "New User was successfully created.";
        }
        
        public IActionResult testcase()
        {
            IEnumerable<User_1> users = _db.User_1s;
            return View("Demo");
        }

        public string NewUserNotCreated()
        {
            return "New User was not created.";
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST action method
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create(User_1 obj, IFormCollection form)
        {
            IEnumerable<User_1> objLoginList = _db.User_1s;

            string pwd = form["Password"];
            string confirmPwd = form["ConfirmPassword"];
            string userName = form["UserName"];

            string errorMsg = "";

            if (objLoginList != null)
            {
                foreach (User_1 login in objLoginList)
                {
                    if (userName == login.UserName)
                    {
                        errorMsg += "Login already exists.";
                    }
                }
            }
            if (pwd != confirmPwd)
            {
                errorMsg += "Password and Confirm Password must match.";
            }

            if (errorMsg != "")
            {
                ViewBag.Message = errorMsg;
                obj.UserName = userName;
                obj.Password = pwd;

                return View("Create");
            }


            //if (ModelState.IsValid)
            {   
                if (errorMsg.Length == 0) {
                    obj.Address = " ";
                    obj.Dob = " ";
                    obj.Email = " ";
                obj.Password = form["Password"];
                    _db.User_1s.Add(obj);    //add new entry to DB
                    _db.SaveChanges();      //goes to the DB and saves all the changes  
                    //return RedirectToAction("Index");
                
                    return RedirectToAction("NewUserCreated");
                } 

            }
            return View("Create");  
        }

        //GET Action method
        /*       public IActionResult LogIn() { 
                   return RedirectToAction("Index");
               }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult demo(IFormCollection form)
        {
            string usr = form["UserName"];
            string pwd = form["Password"];

            //string specialSymbols = " !#\"$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            //string digits = "0123456789";

            //int isSpecSymb = 0;
            //int isDig = 0;
            //int isUprCs = 0;
            //int isMinReached = 0;

            //if (usr != null && pwd != null)
            //{
            //    //if a password contains at least one special symbol
            //    foreach (char item in pwd)
            //    {
            //        foreach(char spec in specialSymbols)
            //        {
            //            if(item == spec)
            //            {
            //                isSpecSymb++;
            //            }
            //        }
            //    }
            //    //if a password contains at least one digit
            //    foreach (char item in pwd)
            //    {
            //        if (Char.IsDigit(item)) 
            //        {
            //            isDig++;
            //        }
            //    }
            //    //if a password contains at least one uppercase symbol
            //    foreach (char item in pwd)
            //    {
            //        if (Char.IsUpper(item)) 
            //        { 
            //            isUprCs++;
            //        }
            //    }
            //    //if a password's length is at least 8 characters
            //    if (pwd.Length >= 8) 
            //    {
            //        isMinReached++;
            //    }
            //}

            //string pwdErrMsg = "";

            //if (isMinReached == 0) 
            //{
            //    pwdErrMsg += "Password must contain at least 8 characters.";
            //}
            //if (isDig == 0) 
            //{
            //    pwdErrMsg += "\r\nPassword must contain one digit.";
            //}
            //if (isSpecSymb == 0) 
            //{
            //    pwdErrMsg += "\r\nPassword must contain one special sybol.";
            //}
            //if (isUprCs == 0)
            //{
            //    pwdErrMsg += "\r\nPassword must contain one uppercase letter.";
            //}

            //if (pwdErrMsg.Length > 0)
            //{
            //    ViewBag.Message = pwdErrMsg;
            //    return View("Index");
            //}
            //else
            //{
                string yes = "no";
                IEnumerable<User_1> objLoginList = _db.User_1s;
                if (objLoginList != null)
                {
                    foreach (User_1 login in objLoginList)
                    {
                        if (login.UserName == usr && login.Password == pwd)
                        {
                            yes = "yes";
                            ViewBag.Message = "You are successfuly logged in.";
                            //return RedirectToAction("Create");
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ViewBag.Message = "Your login or password is incorrect";
                return View("Index");
           // }
        }

 

 /*       public string demo(IFormCollection form) {
            
            string usr = form["UserName"];
            string pwd = form["Password"];
            string yes = "no";
            IEnumerable<Login> objLoginList = _db.Logins;
            if (objLoginList != null) {
                foreach(Login login in objLoginList) {
                    if (login.UserName == usr && login.Password == pwd) {
                        yes = "yes";
                    }
                }
            }
            
            return "Log in as " + usr + ", with password" + pwd + "           " + yes;
            
        }
*/  
     
    }
}
