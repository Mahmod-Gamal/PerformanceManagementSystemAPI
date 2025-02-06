using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<Result<IEnumerable<DepartmentDtoResponse>>>
    {
    }
}
