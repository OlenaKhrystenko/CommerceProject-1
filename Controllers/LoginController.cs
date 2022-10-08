using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

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

        //GET action method
        public IActionResult Create()
        {
            return View();
        }
        //POST action method
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create(Login obj)
        {
            if (ModelState.IsValid)
            {
                _db.Logins.Add(obj);    //add new entry to DB
                _db.SaveChanges();      //goes to the DB and saves all the changes  
                return RedirectToAction("Index");
            }
            return View(obj);  
        }

        //GET Action method
        /*       public IActionResult LogIn() { 
                   return RedirectToAction("Index");
               }
        */

        public IActionResult demo(IFormCollection form)
        {
            string usr = form["UserName"];
            string pwd = form["Password"];
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
                        return RedirectToAction("Demo");
                    }
                    else {
                        ViewBag.Message = "Your login or password is incorrect";
                    }
                }
            }
            
            return View();

            //return "Log in as " + usr + ", with password" + pwd + "           " + yes;

        }

/*        public string demo(IFormCollection form) {
            
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
