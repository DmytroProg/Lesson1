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

    [HttpPost]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _studentService.DeleteStudent(id);

        return RedirectToAction(nameof(GetStudents));
    }

    public async Task<IActionResult> UpdateStudent(int id)
    {
        var student = (await _studentService.GetStudents()).First(x => x.Id == id);
        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStudent(Student student)
    {
        await _studentService.UpdateStudent(student);

        return RedirectToAction(nameof(GetStudents));
    }
}
