using CRUD_Application.Models;

namespace CRUD_Application.Services.Interfaces
{
    public interface IStudentManagement
    {
        Task<List<Student>> GetAllStudents();
        Task<string> StudentCreate(Student obj);
    }
}
