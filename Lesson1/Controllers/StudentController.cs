using Lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IActionResult> GetStudents()
    {
        //ViewBag.Student = _student;
        //ViewData["Student"] = _student;
        return View(await _studentService.GetStudents());
    }
}
