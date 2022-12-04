using Microsoft.AspNetCore.Mvc;
using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
        public IActionResult Index(int? id)
        {
            var model = new DonationForm();
            model.FundraiserID =Convert.ToInt32(id);
           
            return View(model);
        }
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

            }
            return View(form);

           
        }

        //GET action method
        //public IActionResult MakeDonation()
        //{
        //    //to do
        //    return View("DonationForm");
        //}

        ////POST Action method
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> MakeDonation([Bind("FormID,Name,Email,PhoneNumber,DonationAmount,DonationType,NameOnCard,CardNumber,MonthYear,CVC,BankName,RoutingNumber,AccountNumber,NameOfAccountHolder,FundraiserID")] DonationForm form)
        //{
        //    try
        //    {


        //        if (ModelState.IsValid)
        //        {
        //            _dbContext.Add(form);
        //            await _dbContext.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
               
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine("invalid data", ex);


        //    }
        //    return View(form);

        //    ////if (ModelState.IsValid)
        //    //{
        //    //    //string donType = form.DonationType.ToString();
        //    //    String donType = collection["DonationType"];
        //    //    string msg = collection["Name"] + " donated " + collection["DonationAmount"] + " via " + donType;
        //    //    ViewBag.Message = msg;
        //    //    form.DonationType = donType;
        //    //    form.Comment = "some comment";

        //    //    _dbContext.donationForms.Add(form);
        //    //    _dbContext.SaveChanges();
        //    //    //return RedirectToAction("Index");   
        //    //}
        //    //return View("DonationForm");
        //}


    }
}
