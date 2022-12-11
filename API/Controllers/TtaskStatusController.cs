using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtaskStatusController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context;

        public TtaskStatusController(AgronomicAppTestUserContext context)
        {
            _context = context;
        }

        // GET: api/TtaskStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TtaskStatus>>> GetTtaskStatuses()
        {
            return await _context.TtaskStatuses.ToListAsync();
        }

        // GET: api/TtaskStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TtaskStatus>> GetTtaskStatus(int id)
        {
            var ttaskStatus = await _context.TtaskStatuses.FindAsync(id);

            if (ttaskStatus == null)
            {
                return NotFound();
            }

            return ttaskStatus;
        }

        // PUT: api/TtaskStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtaskStatus(int id, TtaskStatus ttaskStatus)
        {
            if (id != ttaskStatus.IdTtaskStatus)
            {
                return BadRequest();
            }

            _context.Entry(ttaskStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtaskStatusExists(id))
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

        // POST: api/TtaskStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TtaskStatus>> PostTtaskStatus(TtaskStatus ttaskStatus)
        {
            _context.TtaskStatuses.Add(ttaskStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTtaskStatus", new { id = ttaskStatus.IdTtaskStatus }, ttaskStatus);
        }

        // DELETE: api/TtaskStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtaskStatus(int id)
        {
            var ttaskStatus = await _context.TtaskStatuses.FindAsync(id);
            if (ttaskStatus == null)
            {
                return NotFound();
            }

            _context.TtaskStatuses.Remove(ttaskStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TtaskStatusExists(int id)
        {
            return _context.TtaskStatuses.Any(e => e.IdTtaskStatus == id);
        }
    }
}
