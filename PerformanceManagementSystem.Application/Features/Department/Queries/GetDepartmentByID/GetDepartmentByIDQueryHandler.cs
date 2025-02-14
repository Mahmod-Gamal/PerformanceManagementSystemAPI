using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDepartmentByIDQuery, Result<DepartmentDtoResponse>>
    {
        public async Task<Result<DepartmentDtoResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            var department = unitOfWork.DepartmentRepository.GetByIdAsync(request.ID).Result;
            if (department == null)
                return Result<DepartmentDtoResponse>.NotFound("Department Not found");
            return Result<DepartmentDtoResponse>.Ok(department.Adapt<DepartmentDtoResponse>());
        }
    }
}
