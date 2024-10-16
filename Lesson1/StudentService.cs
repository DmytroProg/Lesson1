using Lesson1.Models;

namespace Lesson1;

public class StudentService : IStudentService
{
    private readonly List<Student> _students;

    public StudentService()
    {
        _students = new List<Student>();
        _students.Add(new Student() { FirstName = "John", LastName = "Jhonson", GPA = 4 });
        _students.Add(new Student() { FirstName = "Jack", LastName = "Jackson", GPA = 2 });
        _students.Add(new Student() { FirstName = "Mary", LastName = "Maryson", GPA = 5 });
    }

    public async Task<Student> AddStudent(Student student)
    {
        _students.Add(student);
        return student;
    }

    public async Task DeleteStudent(int id)
    {
        _students.Remove(_students.First(x => x.Id == id));
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        return _students;
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        int index = _students.IndexOf(_students.First(x => x.Id == student.Id));
        _students[index] = student;
        return student;
    }
}
