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
        public async Task<IActionResult> Index([Bind("FormID,Name,Email,PhoneNumber,DonationAmount,DonationType,NameOnCard,CardNumber,MonthYear,CVC,BankName,RoutingNumber,AccountNumber,NameOfAccountHolder,FundraiserID")] DonationForm form)
        {
            try
            {


                if (ModelState.IsValid)
                {
                  
                   
                    if (form.FundraiserID > 0)
                    {
                        var fundraiser = await _dbContext.Fundraisers.FindAsync(form.FundraiserID);
                      
                        var fundraiserbydonationform = from t in _dbContext.donationForms
                                       where t.FundraiserID == form.FundraiserID
                                       select t.DonationAmount;
                        double total = fundraiserbydonationform.Sum(x => Convert.ToInt32(x));
                        var donationamount =   total + form.DonationAmount;


                        double percentage = (int)Math.Round(((double)donationamount / (double)fundraiser.Amount) * 100);
                       


                        fundraiser.Goals = percentage;
                        if (fundraiser.Amount > donationamount)
                        {
                            _dbContext.Add(form);
                            await _dbContext.SaveChangesAsync();
                            _dbContext.Update(fundraiser);
                            await _dbContext.SaveChangesAsync();
                            return RedirectToAction("Index", "StartFundraising");

                        }
                        else
                        {
                            return View(form.FundraiserID);
                            
                        }
                       
                    }
                   
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("invalid data", ex);


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
