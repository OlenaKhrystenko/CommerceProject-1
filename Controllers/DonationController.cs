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
        public IActionResult MakeDonation(DonationForm form, IFormCollection formColl) {
            if (ModelState.IsValid)
            {
                form.DonationType = formColl["DonationType"];
                _dbContext.donationForms.Add(form);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View("DonationForm");
        }


    }
}
