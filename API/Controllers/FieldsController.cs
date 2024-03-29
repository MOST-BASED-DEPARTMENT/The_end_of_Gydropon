﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers;

[Route("api/[controller]/{id:int}")]
[ApiController]
public class FieldsController : ControllerBase
{
    private readonly AgronomicAppTestUserContext _context = new();

    // GET: api/Fields
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Field>>> GetFields()
    {
        return await _context.Fields.ToListAsync();
    }

    // GET: api/Fields/5
    [HttpGet("")]
    public async Task<ActionResult<Field>> GetField(int id)
    {
        Field? field = await _context.Fields.FindAsync(id);

        if (field == null)
        {
            return NotFound();
        }

        return field;
    }

    // PUT: api/Fields/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("")]
    public async Task<IActionResult> PutField(int id, Field field)
    {
        if (id != field.IdField)
        {
            return BadRequest();
        }

        _context.Entry(field).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FieldExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/Fields
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Field>> PostField(Field field, int id)
    {
        _context.Fields.Add(field);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetField", new { id = field.IdField }, field);
    }

    // DELETE: api/Fields/5
    [HttpDelete("")]
    public async Task<IActionResult> DeleteField(int id)
    {
        Field? field = await _context.Fields.FindAsync(id);
        if (field == null)
        {
            return NotFound();
        }

        _context.Fields.Remove(field);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FieldExists(int id)
    {
        return _context.Fields.Any(e => e.IdField == id);
    }
}