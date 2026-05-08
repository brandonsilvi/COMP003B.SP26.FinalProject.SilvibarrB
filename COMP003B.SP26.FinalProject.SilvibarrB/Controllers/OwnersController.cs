using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers
{

    public class OwnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Owners.ToListAsync());
        }
//DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _context.Owners
                .Include(o => o.Pets)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null) return NotFound();
            return View(owner);
        }

        public IActionResult Create()
        {
            return View();
        }
//CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(owner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(owner);
        }
//EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null) return NotFound();
            return View(owner);
        }
//EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] Owner owner)
        {
            if (id != owner.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Owners.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(owner);
        }
//DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _context.Owners.FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null) return NotFound();
            return View(owner);
        } 
//DELETE        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner != null) _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}