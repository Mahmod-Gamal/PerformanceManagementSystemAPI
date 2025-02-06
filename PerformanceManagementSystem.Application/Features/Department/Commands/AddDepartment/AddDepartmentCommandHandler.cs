using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;


namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddDepartmentCommand, Result<DepartmentDtoResponse>>
    {
        public async Task<Result<DepartmentDtoResponse>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Validator = new AddDepartmentCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DepartmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

          var addDepartmentDtoResponse = new DepartmentDtoResponse();
            return Result<DepartmentDtoResponse>.Ok(addDepartmentDtoResponse);
        }
    }
}
