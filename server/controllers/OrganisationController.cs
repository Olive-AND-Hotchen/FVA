using System.Collections;
using FVA.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace Server.controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganisationController(OdinDatabaseContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable>> GetOrganisations()
    {
        return await context.Organisations.Include(x => x.Services).Select(
            x => new
            {
                orgId = x.Id,
                services = x.Services
            }
        ).ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Organisation>> GetOrganisation(int id)
    {
        var organisation = await context.Organisations.FindAsync(id);

        if (organisation == null) return NotFound();

        return organisation;
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutOrganisation(int id, Organisation organisation)
    {
        if (id != organisation.Id) return BadRequest();

        context.Entry(organisation).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrganisationExists(id)) return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Organisation>> PostOrganisation(Organisation organisation)
    {
        context.Organisations.Add(organisation);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetOrganisation", new { id = organisation.Id }, organisation);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrganisation(int id)
    {
        var organisation = await context.Organisations.FindAsync(id);
        if (organisation == null) return NotFound();

        context.Organisations.Remove(organisation);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrganisationExists(int id)
    {
        return context.Organisations.Any(e => e.Id == id);
    }
}