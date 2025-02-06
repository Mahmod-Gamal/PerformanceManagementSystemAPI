using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Department.Queries.GetDepartmentByID;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDepartmentByIDQuery, Result<DepartmentDtoResponse>>
    {
        public Task<Result<DepartmentDtoResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
