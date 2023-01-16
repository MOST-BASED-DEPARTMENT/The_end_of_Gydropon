using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

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
        Ttask? ttask = await _context.Ttasks.FindAsync(id);

        if (ttask == null)
        {
            return NotFound();
        }

        return ttask;
    }

    /*[HttpGet, Route("GetTasksProcedure")]
    public ICollection<Ttask> GetTasksProcedure(int? id)
    {
        var param_id = new SqlParameter("@ID_Ttask", id);
        var result = _context.Ttasks.FromSql($"Get_Ttask_Card @ID_Ttask", param_id).ToList();
        return result;
    }*/
}