using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsTypesController : ControllerBase
{
    private readonly AgronomicAppTestUserContext _context = new();

    // GET: api/PlantsTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlantsType>>> GetPlantsTypes()
    {
        return await _context.PlantsTypes.ToListAsync();
    }

    // GET: api/PlantsTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PlantsType>> GetPlantsType(int id)
    {
        var plantsType = await _context.PlantsTypes.FindAsync(id);

        if (plantsType == null)
        {
            return NotFound();
        }

        return plantsType;
    }

    // PUT: api/PlantsTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlantsType(int id, PlantsType plantsType)
    {
        if (id != plantsType.IdPlantType)
        {
            return BadRequest();
        }

        _context.Entry(plantsType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlantsTypeExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    // POST: api/PlantsTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PlantsType>> PostPlantsType(PlantsType plantsType)
    {
        _context.PlantsTypes.Add(plantsType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPlantsType", new { id = plantsType.IdPlantType }, plantsType);
    }

    // DELETE: api/PlantsTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlantsType(int id)
    {
        var plantsType = await _context.PlantsTypes.FindAsync(id);
        if (plantsType == null)
        {
            return NotFound();
        }

        _context.PlantsTypes.Remove(plantsType);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PlantsTypeExists(int id)
    {
        return _context.PlantsTypes.Any(e => e.IdPlantType == id);
    }
}