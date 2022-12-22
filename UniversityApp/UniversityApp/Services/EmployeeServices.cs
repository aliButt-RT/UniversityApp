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
        private readonly IDepartmentServices _departmentServices;

        public EmployeeServices(UniDbContext uniDbContext, IMapper mapper, IDepartmentServices departmentServices)
        {
            _uniDbContext = uniDbContext;
            _mapper = mapper;
            _departmentServices = departmentServices;
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

        public async Task<OperationResult> CreateEmployee(string departmentName, EmployeeViewModel employeeVm)
        {
            if (!_departmentServices.IsDepartmentExist(departmentName).GetAwaiter().GetResult())
            {
                return OperationResult.Failure("No such department Exist.");
            }

            var employeeEnitity = _mapper.Map<Employee>(employeeVm);
            employeeEnitity.Department = departmentName;

            try
            {
                var employeeCreated = await _uniDbContext.Employees.AddAsync(employeeEnitity);
                await _uniDbContext.SaveChangesAsync();
                return OperationResult.Success("Employee record Inserted Succesfully.",employeeCreated);
            }
            catch(Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }

        }
        //end of class
    }
}
