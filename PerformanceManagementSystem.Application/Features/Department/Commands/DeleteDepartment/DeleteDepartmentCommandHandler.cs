﻿using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepartmentCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Validator = new DeleteDepartmentCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var department = unitOfWork.DepartmentRepository.GetByIdAsync(request.ID).Result;
            if (department is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("Department Not Found");

            unitOfWork.DepartmentRepository.Remove(department);
            unitOfWork.CommitAsync();

            return Result<AcknowledgmentDtoResponse>.Ok(new("Deleted Successfully"));
        }
    }
}
