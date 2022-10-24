using Microsoft.AspNetCore.Mvc;
using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Policy;

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
            return View("DonationForm");
        }

        //GET action method
        public IActionResult MakeDonation() { 
            //to do
            return View("DonationForm");
        }

        //POST Action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeDonation(DonationForm form, IFormCollection collection) {
            //if (ModelState.IsValid)
            {
                //string donType = form.DonationType.ToString();
                String donType = collection["DonationType"];
                string msg = collection["Name"] + " donated " + collection["DonationAmount"] + " via " + donType;
                ViewBag.Message = msg;
                form.DonationType = donType;
                form.Comment = "some comment";

                _dbContext.donationForms.Add(form);
                _dbContext.SaveChanges();
                //return RedirectToAction("Index");   
            }
            return View("DonationForm");
        }


    }
}
