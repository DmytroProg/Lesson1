using Lesson1.Models;

namespace Lesson1;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudents();

    Task<Student> AddStudent(Student student);
    Task DeleteStudent(int id); // soft-delete
    Task<Student> UpdateStudent(Student student);
}
