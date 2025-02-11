using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateDepartmentCommand, Result<DepartmentDtoResponse>>
    {
        public async Task<Result<DepartmentDtoResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateDepartmentCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DepartmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var department = unitOfWork.DepartmentRepository.GetByIdAsync(request.ID).Result;
            if (department == null)
                return Result<DepartmentDtoResponse>.NotFound("Department Not found");

            request.Adapt(department);
            unitOfWork.CommitAsync();

            return Result<DepartmentDtoResponse>.Ok(department.Adapt<DepartmentDtoResponse>());
        }
    }
}
