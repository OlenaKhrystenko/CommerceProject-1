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
        //10/7/2022
        [HttpPost]
        public IActionResult LogIn(FormCollection fc)
        {
         
            {
                ViewBag.UserName = fc["UserName"];
                ViewBag.Password = fc["Password"];

                return View();
            }
        }
  
     
    }
}
