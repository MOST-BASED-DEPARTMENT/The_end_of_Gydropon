using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturalMachineriesController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context;

        public AgriculturalMachineriesController(AgronomicAppTestUserContext context)
        {
            _context = context;
        }

        // GET: api/AgriculturalMachineries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgriculturalMachinery>>> GetAgriculturalMachineries()
        {
            return await _context.AgriculturalMachineries.ToListAsync();
        }

        // GET: api/AgriculturalMachineries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgriculturalMachinery>> GetAgriculturalMachinery(int id)
        {
            var agriculturalMachinery = await _context.AgriculturalMachineries.FindAsync(id);

            if (agriculturalMachinery == null)
            {
                return NotFound();
            }

            return agriculturalMachinery;
        }

        // PUT: api/AgriculturalMachineries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgriculturalMachinery(int id, AgriculturalMachinery agriculturalMachinery)
        {
            if (id != agriculturalMachinery.IdAgriculturalMachinery)
            {
                return BadRequest();
            }

            _context.Entry(agriculturalMachinery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgriculturalMachineryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AgriculturalMachineries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgriculturalMachinery>> PostAgriculturalMachinery(AgriculturalMachinery agriculturalMachinery)
        {
            _context.AgriculturalMachineries.Add(agriculturalMachinery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgriculturalMachinery", new { id = agriculturalMachinery.IdAgriculturalMachinery }, agriculturalMachinery);
        }

        // DELETE: api/AgriculturalMachineries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgriculturalMachinery(int id)
        {
            var agriculturalMachinery = await _context.AgriculturalMachineries.FindAsync(id);
            if (agriculturalMachinery == null)
            {
                return NotFound();
            }

            _context.AgriculturalMachineries.Remove(agriculturalMachinery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgriculturalMachineryExists(int id)
        {
            return _context.AgriculturalMachineries.Any(e => e.IdAgriculturalMachinery == id);
        }
    }
}
