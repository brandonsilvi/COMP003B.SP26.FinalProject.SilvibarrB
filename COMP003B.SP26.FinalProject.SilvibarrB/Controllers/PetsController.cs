using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers
{

    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        //GET PETS
        public async Task<IActionResult> Index()
        {
            var pets = _context.Pets.Include(p => p.Owner);
            return View(await pets.ToListAsync());
        }
        //GET PETS DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null) return NotFound();
            return View(pet);
        }
        //GET PET CREATE
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FirstName");
            return View();
        }
        //POST PET CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Species,Breed,Age,OwnerId")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FirstName", pet.OwnerId);
            return View(pet);
        }
        //GET PET EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FirstName", pet.OwnerId);
            return View(pet);
        }
        //POST PET EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Species,Breed,Age,OwnerId")] Pet pet)
        {
            if (id != pet.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pets.Any(e => e.Id == pet.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FirstName", pet.OwnerId);
            return View(pet);
        }
        //GET PET DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null) return NotFound();
            return View(pet);
        }
        // POST PET DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
                _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}