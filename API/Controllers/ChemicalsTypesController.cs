using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChemicalsTypesController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context = new();

        // GET: api/ChemicalsTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChemicalsType>>> GetChemicalsTypes()
        {
            return await _context.ChemicalsTypes.ToListAsync();
        }

        // GET: api/ChemicalsTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChemicalsType>> GetChemicalsType(int id)
        {
            var chemicalsType = await _context.ChemicalsTypes.FindAsync(id);

            if (chemicalsType == null)
            {
                return NotFound();
            }

            return chemicalsType;
        }

        // PUT: api/ChemicalsTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChemicalsType(int id, ChemicalsType chemicalsType)
        {
            if (id != chemicalsType.IdChemicalType)
            {
                return BadRequest();
            }

            _context.Entry(chemicalsType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChemicalsTypeExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ChemicalsTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChemicalsType>> PostChemicalsType(ChemicalsType chemicalsType)
        {
            _context.ChemicalsTypes.Add(chemicalsType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChemicalsType", new { id = chemicalsType.IdChemicalType }, chemicalsType);
        }

        // DELETE: api/ChemicalsTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChemicalsType(int id)
        {
            var chemicalsType = await _context.ChemicalsTypes.FindAsync(id);
            if (chemicalsType == null)
            {
                return NotFound();
            }

            _context.ChemicalsTypes.Remove(chemicalsType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChemicalsTypeExists(int id)
        {
            return _context.ChemicalsTypes.Any(e => e.IdChemicalType == id);
        }
    }
}
