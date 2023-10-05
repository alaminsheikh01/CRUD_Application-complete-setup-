using CRUD_Application.Models;
using CRUD_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeManagement _employeeManager;

        public EmployeeController(IEmployeeManagement employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var employees = await _employeeManager.EmployeeAll();

                if(employees == null)
                {
                    return NotFound();
                }
                else
                    return Ok(employees);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeeById(int id)
        {
            try
            {
                var employee = await _employeeManager.EmployeeById(id);
                
                if(employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EmployeeCreate (Employee obj)
        {
            try
            {
                var result = await _employeeManager.EmployeeCreate(obj);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
