using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ttask>> GetTtask(int id)
        {
            var ttask = await _context.Ttasks.FindAsync(id);

            if (ttask == null)
            {
                return NotFound();
            }

            return ttask;
        }

        [HttpGet, Route("GetTasksProcedure")]
        public HttpResponseMessage GetTasksProcedure(int? id)
        {
            try
            {
                var taskId = new SqlParameter("@Ttask_id", id);
                var courseList = _context.Database.SqlQuery<Ttask>($"EXEC Get_Ttask_Card @ID_Ttask={taskId.Value}")
                    .ToList();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JArray.FromObject(courseList).ToString(), Encoding.UTF8,
                        "application/json")
                };
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
