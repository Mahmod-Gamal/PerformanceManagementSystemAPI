using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommand : IRequest<Result<DepartmentDtoResponse>>
    {
        public string Name { get; set; }
        public int? ManagerId { get; set; }
    }
}
