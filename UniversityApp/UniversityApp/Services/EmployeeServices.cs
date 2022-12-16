using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Abstractions;
using UniversityApp.Data;
using UniversityApp.Models;
using UniversityApp.ViewModels;

namespace UniversityApp.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly UniDbContext _uniDbContext;
        private readonly IMapper _mapper;

        public EmployeeServices(UniDbContext uniDbContext, IMapper mapper)
        {
            _uniDbContext = uniDbContext;
            _mapper = mapper;
        }
        public async Task<OperationResult> GetEmployeeDetail(string employeeId)
        {
            var employeeResult = await _uniDbContext.Employees.FirstOrDefaultAsync(e => e.EID == employeeId);

            if (employeeResult == null)
                return OperationResult.Failure("NO employee exist");

            var emplyeeVm = _mapper.Map<EmployeeViewModel>(employeeResult);
            return OperationResult.Success("Record fetched successfully.", emplyeeVm);
        }
        public async Task<OperationResult> GetEmployeeDetail()
        {
            var employeeResult = await _uniDbContext.Employees.ToListAsync();
            var employeeListVm = _mapper.Map<List<EmployeeViewModel>>(employeeResult);
            return OperationResult.Success("Record fetched successfully.", employeeListVm);
        }
        //end of class
    }
}
