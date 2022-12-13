using System.Data.SqlClient;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TtasksController : ControllerBase
    {
        private readonly AgronomicAppTestUserContext _context = new();

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

        [HttpGet, Route("api/TestProcedure/{country}")]
        public List<Ttask> GetTasks(string country)
        {
            var parameter = new SqlParameter
            {
                ParameterName = "Country",
                Value = "USA"
            };

            var countries = _context.web_api_Test.SqlQuery<web_api_Test>("exec FindPeople @Country", parameter).ToList<web_api_Test>();
        }
    }
}
