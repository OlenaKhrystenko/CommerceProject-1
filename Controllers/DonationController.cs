using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeDonation() { 
            //to do
            return View("DonationForm");
        }
    }
}
