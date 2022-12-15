using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Abstractions;
using UniversityApp.Data;
using UniversityApp.Models;

namespace UniversityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly UniDbContext _uniDbContext;
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(UniDbContext uniDbContext,
                                    IDepartmentServices departmentServices)
        {
            _uniDbContext = uniDbContext;
            _departmentServices = departmentServices;
        }
         
        //GetAll
        [HttpGet("getAllDepartment")]
        public IActionResult GetAll()
        {
            var listOfDepartments =  _uniDbContext.Departments.ToList();
            if (listOfDepartments is not null)
            {
                return Ok(new OperationResult(true, "Successfully added", listOfDepartments));
                
            }

            else return BadRequest("List is empty.");
        }

        //insert
        [HttpPost("Insert")]
        public IActionResult Insert(Department model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _uniDbContext.Departments.Add(model);
                    _uniDbContext.SaveChanges();
                    return Ok(model);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Model state are not valid");            
        }

        [HttpGet("DepartmentsCount")]
        public IActionResult GetAllDepartmentCount(string departmentName)
        {
            if (string.IsNullOrEmpty(departmentName))
            {
                return BadRequest("No department Found");
            }

            var result = _departmentServices.GetDepartmentsCount(departmentName).GetAwaiter().GetResult();
            
            if(result.Failed)
                return NoContent();

            return Ok(result.Payload);
          
        }


        [HttpGet("AllVCsList")]
        public IActionResult GetAllVCsList()
        {
            var result = _departmentServices.AllVCsList().GetAwaiter().GetResult();

            if (result.Failed)
                return NoContent();

            return Ok(result.Payload);
        }


        [HttpGet("AllVCsList/For")]
        public IActionResult GetAllVCsList(string departmentName)
        {
            if (string.IsNullOrEmpty(departmentName))
            {
                return BadRequest("No department Found");
            }

            var result = _departmentServices.AllVCsList(departmentName).GetAwaiter().GetResult();

            if (result.Failed)
                return NoContent();

            return Ok(result.Payload);

        }
    }
}
