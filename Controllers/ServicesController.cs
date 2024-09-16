using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FVA.Database;
using FVA.Database.Models;

namespace FVA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(OdinDatabaseContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await context.Services.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            context.Entry(service).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            context.Services.Add(service);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            context.Services.Remove(service);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return context.Services.Any(e => e.Id == id);
        }
    }
}
