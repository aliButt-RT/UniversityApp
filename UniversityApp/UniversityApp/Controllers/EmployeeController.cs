using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Abstractions;
using UniversityApp.ViewModels;

namespace UniversityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet("GetEmployeeDetail")]
        public async Task<IActionResult> GetEmployeeDetail(string employeeId)
        {
            var result = await _employeeServices.GetEmployeeDetail(employeeId);
            return Ok(result.Payload);
        }

        [HttpGet("GetAllEmployeeDetail")]
        public async Task<IActionResult> GetEmployeeDetail()
        {
            var result = await _employeeServices.GetEmployeeDetail();
            return Ok(result.Payload);
        }

        [HttpPost("Creat")]
        public async Task<IActionResult> Creat(string departmentName,EmployeeViewModel employeeVm)
        {
            var result = await _employeeServices.CreateEmployee(departmentName, employeeVm);
            if (result.Succeeded)
            {
                return Ok(result.Payload);
            }
            return BadRequest(result.Message);
        }

    }
}
