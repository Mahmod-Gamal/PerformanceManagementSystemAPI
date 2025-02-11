using MediatR;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<Result<IEnumerable<DepartmentDtoResponse>>>
    {
    }
}
