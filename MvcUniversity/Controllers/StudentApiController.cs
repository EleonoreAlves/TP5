using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;

namespace MvcUniversity.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentApiController : ControllerBase
{
    private readonly UniversityContext _context;

    public StudentApiController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/MovieApi
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return await _context.Students.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudents(int id)
    {
        var movie = await _context.Students.FindAsync(id);
        if (movie == null)
            return NotFound();
        return movie;
    }
}