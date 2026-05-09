using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP26.FinalProject.SilvibarrB.Data;
using COMP003B.SP26.FinalProject.SilvibarrB.Models;

namespace COMP003B.SP26.FinalProject.SilvibarrB.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServicesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GET API SERVICES
        [HttpGet]
        public async Task<IActionResult> GetService()
        {
            return Ok(await _context.Services.ToListAsync());
        }
        //GET API SERVICES+
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }
        //POST API SERVICES
        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return Ok(service);
        }
        //PUT API SERVICES+
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return Ok(service);
        }
        //DELETE API SERVICES+
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }

}