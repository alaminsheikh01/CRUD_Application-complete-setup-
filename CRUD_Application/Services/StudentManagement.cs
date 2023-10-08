using CRUD_Application.Context;
using CRUD_Application.Models;
using CRUD_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Services
{
    public class StudentManagement : IStudentManagement
    {

        private readonly ApplicationDbContext _context;

        public StudentManagement(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                var data =await (from student in _context.Students select student).ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> StudentCreate(Student obj)
        {
            var message = "";
            try
            {
                List<Student> CreatedList = new List<Student>();
                List<Student> UpdatedList = new List<Student>();

                var data = await _context.Students.Where(x => x.Id == obj.Id).FirstOrDefaultAsync();

                if(data != null)
                {
                    data.Age = obj.Age;
                    data.Name = obj.Name;
                    data.StudentId = obj.StudentId;
                    data.Number = obj.Number;
                    data.AdmissionDate = DateTime.Now;
                    data.BirthDate = DateTime.Now;

                    UpdatedList.Add(data);
                }
                else
                {
                    data = new Student();
                    
                    data.Age=obj.Age;
                    data.Name=obj.Name;
                    data.StudentId=obj.StudentId;
                    data.Number=obj.Number;
                    data.AdmissionDate=DateTime.Now;
                    data.BirthDate=DateTime.Now;

                    CreatedList.Add(data);
                }

                if (CreatedList.Any())
                {
                    await _context.Students.AddRangeAsync(CreatedList);
                    await _context.SaveChangesAsync();

                    message = "Save Successfully!";
                }

                if(UpdatedList.Any())
                {
                    _context.Students.UpdateRange(UpdatedList);
                    await _context.SaveChangesAsync();

                    message = "Update Successfully!";
                }

                return message;

            }catch (Exception ex)
            {
                return message;
            }
        }
    }
}
