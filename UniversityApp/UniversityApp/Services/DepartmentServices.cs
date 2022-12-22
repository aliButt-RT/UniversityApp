using Microsoft.EntityFrameworkCore;
using UniversityApp.Abstractions;
using UniversityApp.Data;
using UniversityApp.Models;

namespace UniversityApp.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly UniDbContext _uniDbContext;

        public DepartmentServices(UniDbContext uniDbContext)
        {
            _uniDbContext = uniDbContext;
        }

        public async Task<OperationResult> GetDepartmentsCount(string departmentName)
        {
            if (IsDepartmentExist(departmentName).GetAwaiter().GetResult())
            {
                var listOfDepartment = await _uniDbContext.Departments.Where(d => d.DName == departmentName).ToListAsync();
                return new OperationResult(true, "Department Count.", listOfDepartment.Count());
            }
            return new OperationResult(false, "No such department Exisr");
        }

        public async Task<OperationResult> AllVCsList()
        {
            var listOfVCs = await _uniDbContext.Departments.Select(d => d.VcName).ToListAsync();
            return new OperationResult(true, "All VC department list.", listOfVCs);
        }

        public async Task<bool> IsDepartmentExist(string departmentName)
        {
            if (await _uniDbContext.Departments.Where(d => d.DName == departmentName).ToListAsync() != null)
                return true;
            return false;
        }

        public async Task<OperationResult> AllVCsList(string departmentName)
        {

            var listOfVCs = await _uniDbContext.Departments.Where(d => d.DName == departmentName).Select(d => d.VcName).ToListAsync();
            return new OperationResult(true, "Specific Department VCs List",listOfVCs);
        }

      
    }
}
