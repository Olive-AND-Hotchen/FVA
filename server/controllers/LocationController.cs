using FVA.Database;
using FVA.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace Server.controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController(OdinDatabaseContext context) : ControllerBase
{
    [HttpGet]
    public async Task<List<Location>> GetLocations()
    {
        return await context.Locations.ToListAsync();
    }

    [HttpGet]
    public async Task<ActionResult<Location>> GetLocation(int id)
    {
        var location = await context.Locations.FindAsync(id);

        if (location == null) return NotFound();

        return location;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutLocation(int id, Location location)
    {
        if (id != location.Id) return BadRequest();

        context.Entry(location).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LocationExists(id)) return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation(Location location)
    {
        context.Locations.Add(location);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetLocation", new { id = location.Id }, location);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var location = await context.Locations.FindAsync(id);
        if (location == null) return NotFound();

        context.Locations.Remove(location);

        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool LocationExists(int id)
    {
        return context.Locations.Any(e => e.Id == id);
    }
}