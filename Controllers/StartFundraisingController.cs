using CommerceProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace CommerceProject.Controllers
{
    public class StartFundraisingController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StartFundraisingController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FirstStepFundraising()
        { 
            return View("FirstStepFund"); 
        }  
    }
}
