using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentByIDQuery : IRequest<Result<DepartmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
