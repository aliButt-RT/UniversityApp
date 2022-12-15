using UniversityApp.Models;

namespace UniversityApp.Abstractions
{
    public interface IDepartmentServices
    {
        Task<OperationResult> GetDepartmentsCount(string departmentName);
        Task<OperationResult> AllVCsList();
        Task<OperationResult> AllVCsList(string departmentName);
      
    }
}
