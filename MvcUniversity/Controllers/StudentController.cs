using Microsoft.AspNetCore.Mvc;
using Data;

namespace Controllers;

public class StudentController : Controller // not ControllerBase!
{
    // mettre undex
    private readonly UniversityContext? _context;
    public StudentController(UniversityContext context)
    {
        _context=context;
    }
    public IActionResult Index()
    {
        return View();
    }
    // GET: /Hello/
}