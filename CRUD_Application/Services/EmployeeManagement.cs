using CRUD_Application.Context;
using CRUD_Application.Models;
using CRUD_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Services
{
    public class EmployeeManagement : IEmployeeManagement

    {
        private readonly ApplicationDbContext _context;

        public EmployeeManagement(ApplicationDbContext _context)
        {
            this._context = _context;
            
        }

        public async Task<List<Employee>> EmployeeAll()
        {
            try
            {
                List<Employee> employees = await (from m in _context.Employees
                                           select m).ToListAsync();


                return employees;

            }catch (Exception ex)
            {
                return new List<Employee>();
            }
        }

        public async Task<Employee> EmployeeById(int? id)
        {
            try
            {
                var employee = await (from m in _context.Employees
                                      where m.Id == id select m).FirstOrDefaultAsync();

                return employee;

            }catch (Exception ex)
            {
                return new Employee();
            }
        }

        public async Task<string> EmployeeCreate(Employee model)
        {
            var message = "";
            try
            {
                List<Employee> CreatedList = new List<Employee>();
                List<Employee> UpdatedList = new List<Employee>();

                
                var data = await _context.Employees.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

                if(data != null)
                {
                    data.Age = model.Age;
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.CreatedDate = DateTime.Now;

                    UpdatedList.Add(data);
                }

                else
                {
                    data = new Employee();

                    data.Age = model.Age;
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.CreatedDate = DateTime.Now;

                    CreatedList.Add(data);
                }

                if (CreatedList.Any())
                {
                    await _context.Employees.AddRangeAsync(CreatedList);
                    await _context.SaveChangesAsync();

                    message = "Save Successfylly";
                }
                if (UpdatedList.Any())
                {
                    _context.Employees.UpdateRange(UpdatedList);
                    await _context.SaveChangesAsync();

                    message = "Update Successfylly";
                }

                return message;


            }catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
