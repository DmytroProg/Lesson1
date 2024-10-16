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

    public IActionResult AddStudent()
    {
        return View();
    }

    public IActionResult ReturnBack()
    {
        return RedirectToAction(nameof(GetStudents));
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        // validation

        await _studentService.AddStudent(student);

        return RedirectToAction(nameof(GetStudents));
    }
}
