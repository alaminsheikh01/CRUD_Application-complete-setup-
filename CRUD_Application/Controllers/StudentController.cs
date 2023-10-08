using CRUD_Application.Models;
using CRUD_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentManagement _studentManagement;

        public StudentController(IStudentManagement studentManagement)
        {
            _studentManagement = studentManagement;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            try
            {
                var data = await _studentManagement.GetAllStudents();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> StudentCreate(Student model)
        {
            try
            {
                var result = await _studentManagement.StudentCreate(model);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
