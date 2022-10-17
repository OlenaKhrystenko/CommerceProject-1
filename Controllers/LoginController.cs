﻿using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
