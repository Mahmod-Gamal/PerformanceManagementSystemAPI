using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Result<DepartmentDtoResponse>>
    {
        public async Task<Result<DepartmentDtoResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateDepartmentCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DepartmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var addDepartmentDtoResponse = new DepartmentDtoResponse();
            return Result<DepartmentDtoResponse>.Ok(addDepartmentDtoResponse);
        }
    }
}
