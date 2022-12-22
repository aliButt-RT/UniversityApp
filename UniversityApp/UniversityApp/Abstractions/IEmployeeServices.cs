using UniversityApp.Models;
using UniversityApp.ViewModels;

namespace UniversityApp.Abstractions
{
    public interface IEmployeeServices
    {
        Task<OperationResult> GetEmployeeDetail(string employeeId);
        Task<OperationResult> GetEmployeeDetail();
        Task<OperationResult> CreateEmployee(string departmentName, EmployeeViewModel employeeVm);
    }
}
