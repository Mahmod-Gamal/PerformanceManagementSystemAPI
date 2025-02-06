using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var acknowledgmentDtoResponse = new AcknowledgmentDtoResponse();
            return Result<AcknowledgmentDtoResponse>.Ok(acknowledgmentDtoResponse);
        }
    }
}
