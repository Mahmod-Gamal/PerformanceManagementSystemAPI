using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration
{
    public class DeleteDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteDurationCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteDurationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new DeleteDurationCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);
            var duration = unitOfWork.DurationRepository.GetByIdAsync(request.ID).Result;
            if (duration is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("Duration Not Found");
            unitOfWork.DurationRepository.Remove(duration);
            unitOfWork.CommitAsync();

            return Result<AcknowledgmentDtoResponse>.Ok(new ("Deleted Successfully"));
        }
    }
}
