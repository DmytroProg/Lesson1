using Lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

public class StudentController : Controller
{
    private Student _student = new Student
    {
        DateOfBirth = DateTime.Now,
        FirstName = "Test",
        LastName = "Test",
        GPA = 5
    };

    public IActionResult GetStudents()
    {
        //ViewBag.Student = _student;
        //ViewData["Student"] = _student;
        return View(_student);
    }
}
