using API.Models;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet, Route("GetTasksProcedure")]
    public IActionResult GetTasksProcedure([FromQuery] int? id)
    {
        var result = _context.Ttasks.FromSql($"EXEC Get_Ttask_Card {id}").ToList();
        return Ok(result);
    }
}