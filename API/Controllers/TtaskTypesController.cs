using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TtaskTypesController : ControllerBase
{
    private readonly AgronomicAppTestUserContext _context = new();

    // GET: api/TtaskTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TtaskType>>> GetTtaskTypes()
    {
        return await _context.TtaskTypes.ToListAsync();
    }

    // GET: api/TtaskTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TtaskType>> GetTtaskType(int id)
    {
        TtaskType? ttaskType = await _context.TtaskTypes.FindAsync(id);

        if (ttaskType == null)
        {
            return NotFound();
        }

        return ttaskType;
    }

    // PUT: api/TtaskTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTtaskType(int id, TtaskType ttaskType)
    {
        if (id != ttaskType.IdTtaskType)
        {
            return BadRequest();
        }

        _context.Entry(ttaskType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TtaskTypeExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/TtaskTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TtaskType>> PostTtaskType(TtaskType ttaskType)
    {
        _context.TtaskTypes.Add(ttaskType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTtaskType", new { id = ttaskType.IdTtaskType }, ttaskType);
    }

    // DELETE: api/TtaskTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTtaskType(int id)
    {
        TtaskType? ttaskType = await _context.TtaskTypes.FindAsync(id);
        if (ttaskType == null)
        {
            return NotFound();
        }

        _context.TtaskTypes.Remove(ttaskType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TtaskTypeExists(int id)
    {
        return _context.TtaskTypes.Any(e => e.IdTtaskType == id);
    }
}