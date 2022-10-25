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
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();
        return student;
    }
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}