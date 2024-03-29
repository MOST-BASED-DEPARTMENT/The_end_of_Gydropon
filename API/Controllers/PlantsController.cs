﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
    private readonly AgronomicAppTestUserContext _context = new();

    // GET: api/Plants
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
    {
        return await _context.Plants.ToListAsync();
    }

    // GET: api/Plants/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Plant>> GetPlant(int id)
    {
        Plant? plant = await _context.Plants.FindAsync(id);

        if (plant == null)
        {
            return NotFound();
        }

        return plant;
    }

    // PUT: api/Plants/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlant(int id, Plant plant)
    {
        if (id != plant.IdPlant)
        {
            return BadRequest();
        }

        _context.Entry(plant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlantExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Plants
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Plant>> PostPlant(Plant plant)
    {
        _context.Plants.Add(plant);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPlant", new { id = plant.IdPlant }, plant);
    }

    // DELETE: api/Plants/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlant(int id)
    {
        Plant? plant = await _context.Plants.FindAsync(id);
        if (plant == null)
        {
            return NotFound();
        }

        _context.Plants.Remove(plant);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PlantExists(int id)
    {
        return _context.Plants.Any(e => e.IdPlant == id);
    }
}