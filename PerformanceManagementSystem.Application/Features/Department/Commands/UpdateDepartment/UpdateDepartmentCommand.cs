using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : ICommand<Result<DepartmentDtoResponse>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public int StatusID { get; set; }
   //     public List<int> CompetincyIDs { get; set; }
    }
}
