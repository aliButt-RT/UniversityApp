using AutoMapper;
using UniversityApp.Models;
using UniversityApp.ViewModels;

namespace UniversityApp.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(
                    a => a.EName,
                    opt => opt.MapFrom(b => b.EName.ToLower()));             
        }
    }
}