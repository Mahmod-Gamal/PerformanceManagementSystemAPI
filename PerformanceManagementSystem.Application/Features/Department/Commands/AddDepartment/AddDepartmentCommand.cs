using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommand : IRequest<Result<DepartmentDtoResponse>>
    {
        public string Name { get; set; }
        public DateTime Start{ get; set; }
        public DateTime End{ get; set; }
    }
}
