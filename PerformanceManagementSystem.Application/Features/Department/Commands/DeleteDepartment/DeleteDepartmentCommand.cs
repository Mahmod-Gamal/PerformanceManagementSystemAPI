using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
