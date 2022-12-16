using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Abstractions;

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
        public IActionResult GetEmployeeDetail(string employeeId)
        {
            var result = _employeeServices.GetEmployeeDetail(employeeId).GetAwaiter().GetResult();
            return Ok(result.Payload);
        }

        [HttpGet("GetAllEmployeeDetail")]
        public IActionResult GetEmployeeDetail()
        {
            var result = _employeeServices.GetEmployeeDetail().GetAwaiter().GetResult();
            return Ok(result.Payload);
        }

    }
}
