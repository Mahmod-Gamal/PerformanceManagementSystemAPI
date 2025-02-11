using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllDepartmentsQuery, Result<IEnumerable<DepartmentDtoResponse>>>
    {
        public async Task<Result<IEnumerable<DepartmentDtoResponse>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<DepartmentDtoResponse>>.Ok(unitOfWork.DepartmentRepository.GetAllAsync().Result.Adapt<IEnumerable<DepartmentDtoResponse>>());

        }
    }
}
