using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtasksController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context;

        public TtasksController(AgronomicAppTestUserContext context)
        {
            _context = context;
        }

        // GET: api/Ttasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ttask>>> GetTtasks()
        {
            return await _context.Ttasks.ToListAsync();
        }

        // GET: api/Ttasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ttask>> GetTtask(int id)
        {
            var ttask = await _context.Ttasks.FindAsync(id);

            if (ttask == null)
            {
                return NotFound();
            }

            return ttask;
        }

        // PUT: api/Ttasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtask(int id, Ttask ttask)
        {
            if (id != ttask.IdTtask)
            {
                return BadRequest();
            }

            _context.Entry(ttask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtaskExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Ttasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ttask>> PostTtask(Ttask ttask)
        {
            _context.Ttasks.Add(ttask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTtask", new { id = ttask.IdTtask }, ttask);
        }

        // DELETE: api/Ttasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtask(int id)
        {
            var ttask = await _context.Ttasks.FindAsync(id);
            if (ttask == null)
            {
                return NotFound();
            }

            _context.Ttasks.Remove(ttask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TtaskExists(int id)
        {
            return _context.Ttasks.Any(e => e.IdTtask == id);
        }
    }
}
