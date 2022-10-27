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

        private string name;
        
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

        public IActionResult NewUserCreated() {
            
            ViewBag.name = name;
            return View("NewUserCreatedView");
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST action method
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create(Login obj, IFormCollection form)
        {
            IEnumerable<Login> objLoginList = _db.Logins;

            string pwd = form["Password"];
            string confirmPwd = form["ConfirmPassword"];
            string userName = form["UserName"];

            string errorMsg = "";

            if (objLoginList != null)
            {
                foreach (Login login in objLoginList)
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

                return View(obj);
            }


            if (ModelState.IsValid)
            {   
                if (errorMsg.Length == 0) { 
                    _db.Logins.Add(obj);    //add new entry to DB
                    _db.SaveChanges();      //goes to the DB and saves all the changes  
                    //return RedirectToAction("Index");
                    name = obj.UserName;
                    return RedirectToAction("NewUserCreated");
                } 

            }
            return View(obj);  
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

            string specialSymbols = " !#\"$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            string digits = "0123456789";

            int isSpecSymb = 0;
            int isDig = 0;
            int isUprCs = 0;
            int isMinReached = 0;

            if (usr != null && pwd != null)
            {
                //if a password contains at least one special symbol
                foreach (char item in pwd)
                {
                    foreach(char spec in specialSymbols)
                    {
                        if(item == spec)
                        {
                            isSpecSymb++;
                        }
                    }
                }
                //if a password contains at least one digit
                foreach (char item in pwd)
                {
                    if (Char.IsDigit(item)) 
                    {
                        isDig++;
                    }
                }
                //if a password contains at least one uppercase symbol
                foreach (char item in pwd)
                {
                    if (Char.IsUpper(item)) 
                    { 
                        isUprCs++;
                    }
                }
                //if a password's length is at least 8 characters
                if (pwd.Length >= 8) 
                {
                    isMinReached++;
                }
            }

            string pwdErrMsg = "";

            if (isMinReached == 0) 
            {
                pwdErrMsg += "Password must contain at least 8 characters.";
            }
            if (isDig == 0) 
            {
                pwdErrMsg += "\r\nPassword must contain one digit.";
            }
            if (isSpecSymb == 0) 
            {
                pwdErrMsg += "\r\nPassword must contain one special sybol.";
            }
            if (isUprCs == 0)
            {
                pwdErrMsg += "\r\nPassword must contain one uppercase letter.";
            }

            if (pwdErrMsg.Length > 0)
            {
                ViewBag.Message = pwdErrMsg;
                return View("Index");
            }
            else
            {
                string yes = "no";
                IEnumerable<Login> objLoginList = _db.Logins;
                if (objLoginList != null)
                {
                    foreach (Login login in objLoginList)
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
            }
        }

        public IActionResult passwordCheck(IFormCollection form) 
        {
            string password = form["Password"];
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Contains('T')) 
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
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
