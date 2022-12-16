using UniversityApp.Models;

namespace UniversityApp.Abstractions
{
    public interface IEmployeeServices
    {
        Task<OperationResult> GetEmployeeDetail(string employeeId);
        Task<OperationResult> GetEmployeeDetail();
    }
}
