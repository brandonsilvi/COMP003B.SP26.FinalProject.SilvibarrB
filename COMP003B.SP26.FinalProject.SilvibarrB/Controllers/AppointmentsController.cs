using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.Groomer).Include(a => a.Pet).Include(a => a.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Groomer)
                .Include(a => a.Pet)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        
        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["GroomerId"] = new SelectList(_context.Groomers, "Id", "FirstName");
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name");
//Modified ServiceId to show the name/price/duration in  the dropdown menu
            ViewData["ServiceId"] = new SelectList(
                _context.Services.AsEnumerable()
                    .Select(s => new
                    {
                        s.Id,
                        DisplayName = $"{s.Name} - ${s.Price} ({s.DurationMinutes} min)"
                    }),
                "Id",
                "DisplayName"
            );

            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentDate,Notes,PetId,GroomerId,ServiceId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroomerId"] = new SelectList(_context.Groomers, "Id", "FirstName", appointment.GroomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name", appointment.PetId);
            ViewData["ServiceId"] = new SelectList(_context.Services.AsEnumerable()
                .Select(s => new
                {
                    s.Id, DisplayName = $"{s.Name} -${s.Price} ({s.DurationMinutes} min)"
                }), "Id", "DisplayName");
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["GroomerId"] = new SelectList(_context.Groomers, "Id", "FirstName", appointment.GroomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name", appointment.PetId);
            //Modified to show name/price/duration for edit
            ViewData["ServiceId"] = new SelectList(
                _context.Services.AsEnumerable()
                    .Select(s => new
                    {
                        s.Id,
                        DisplayName = $"{s.Name} - ${s.Price} ({s.DurationMinutes} min)"
                    }),
                "Id",
                "DisplayName",
                appointment.ServiceId
            );
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentDate,Notes,PetId,GroomerId,ServiceId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["GroomerId"] = new SelectList(_context.Groomers, "Id", "FirstName", appointment.GroomerId);
            ViewData["PetId"] = new SelectList(_context.Pets, "Id", "Name", appointment.PetId);
            //Same Modification to correct drop down menus.
            ViewData["ServiceId"] = new SelectList(
                _context.Services.AsEnumerable()
                    .Select(s => new
                    {
                        s.Id,
                        DisplayName = $"{s.Name} - ${s.Price} ({s.DurationMinutes} min)"
                    }),
                "Id",
                "DisplayName",
                appointment.ServiceId
            );
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.Groomer)
                .Include(a => a.Pet)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
