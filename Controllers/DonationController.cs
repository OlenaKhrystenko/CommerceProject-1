﻿using Microsoft.AspNetCore.Mvc;
using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class DonationController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        //constructor
        public DonationController(ApplicationDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET action method
        public IActionResult MakeDonation() { 
            //to do
            return View("DonationForm");
        }

        //POST Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeDonation(DonationForm form) {
            if (!ModelState.IsValid)
            {
                _dbContext.donationForms.Add(form);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View(form);
        }


    }
}
