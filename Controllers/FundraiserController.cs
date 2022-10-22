using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class FundraiserController : Controller
    {
        private readonly ApplicationDBContext _db;

        public FundraiserController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FundraiserListView() 
        {
            IEnumerable<Fundraiser> objFundraiserList = _db.Fundraisers;

            return View(objFundraiserList);
        }
    }
}
