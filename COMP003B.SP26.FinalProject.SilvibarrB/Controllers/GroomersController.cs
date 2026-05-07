using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers
{

    public class GroomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET GROOMERS
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groomers.ToListAsync());
        }

        //GET GROOMERS DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var groomer = await _context.Groomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groomer == null) return NotFound();
            return View(groomer);
        }

        // GET GROOMER CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST GROOMERS CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Specialty,HireDate")] Groomer groomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(groomer);
        }

        // GET GROOMER EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var groomer = await _context.Groomers.FindAsync(id);
            if (groomer == null) return NotFound();
            return View(groomer);
        }

        //POST GROOMER EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,FirstName,LastName,Specialty,HireDate")]
            Groomer groomer)
        {
            if (id != groomer.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Groomers.Any(e => e.Id == groomer.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(groomer);
        }

        // GET GROOMER DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var groomer = await _context.Groomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groomer == null) return NotFound();
            return View(groomer);
        }

        //POST GROOMER DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groomer = await _context.Groomers.FindAsync(id);
            if (groomer != null)
            {
                _context.Groomers.Remove(groomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
