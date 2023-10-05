using CRUD_Application.Models;

namespace CRUD_Application.Services.Interfaces
{
    public interface IEmployeeManagement
    {
        Task<List<Employee>> EmployeeAll();
        Task<Employee> EmployeeById(int? id);
        Task<string> EmployeeCreate(Employee model);
    }
}
