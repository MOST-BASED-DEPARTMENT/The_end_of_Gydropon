using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgriculturalMachineryTypesController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context;

        public AgriculturalMachineryTypesController(AgronomicAppTestUserContext context)
        {
            _context = context;
        }

        // GET: api/AgriculturalMachineryTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgriculturalMachineryType>>> GetAgriculturalMachineryTypes()
        {
            return await _context.AgriculturalMachineryTypes.ToListAsync();
        }

        // GET: api/AgriculturalMachineryTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgriculturalMachineryType>> GetAgriculturalMachineryType(int id)
        {
            var agriculturalMachineryType = await _context.AgriculturalMachineryTypes.FindAsync(id);

            if (agriculturalMachineryType == null)
            {
                return NotFound();
            }

            return agriculturalMachineryType;
        }

        // PUT: api/AgriculturalMachineryTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgriculturalMachineryType(int id, AgriculturalMachineryType agriculturalMachineryType)
        {
            if (id != agriculturalMachineryType.IdAgriculturalMachineryType)
            {
                return BadRequest();
            }

            _context.Entry(agriculturalMachineryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgriculturalMachineryTypeExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/AgriculturalMachineryTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgriculturalMachineryType>> PostAgriculturalMachineryType(AgriculturalMachineryType agriculturalMachineryType)
        {
            _context.AgriculturalMachineryTypes.Add(agriculturalMachineryType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgriculturalMachineryType", new { id = agriculturalMachineryType.IdAgriculturalMachineryType }, agriculturalMachineryType);
        }

        // DELETE: api/AgriculturalMachineryTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgriculturalMachineryType(int id)
        {
            var agriculturalMachineryType = await _context.AgriculturalMachineryTypes.FindAsync(id);
            if (agriculturalMachineryType == null)
            {
                return NotFound();
            }

            _context.AgriculturalMachineryTypes.Remove(agriculturalMachineryType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgriculturalMachineryTypeExists(int id)
        {
            return _context.AgriculturalMachineryTypes.Any(e => e.IdAgriculturalMachineryType == id);
        }
    }
}
