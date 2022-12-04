using CommerceProject.Data;
using CommerceProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceProject.Controllers
{
    public class StartFundraisingController : Controller
    {
        private readonly ApplicationDBContext _context;
        public StartFundraisingController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Fundraisers = _context.Fundraisers.ToList(); 
            return View(Fundraisers);
        }

        public async Task<IActionResult> Create()
        {
            
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundraiserID,Title,Description,Imagelink,Amount")] Fundraisers data)
        {



            if (ModelState.IsValid)
            {
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type = await _context.Fundraisers.FindAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            return View(type);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FundraiserID,Title,Description,Imagelink,Amount")] Fundraisers test)
        {
            if (test.FundraiserID == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExists(test.FundraiserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type = await _context.Fundraisers
                .FirstOrDefaultAsync(m => m.FundraiserID == id);
            if (type == null)
            {
                return NotFound();
            }

            return View(type);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type = await _context.Fundraisers.FindAsync(id);
            _context.Fundraisers.Remove(type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _context.Fundraisers.Any(e => e.FundraiserID == id);
        }
    }
}
