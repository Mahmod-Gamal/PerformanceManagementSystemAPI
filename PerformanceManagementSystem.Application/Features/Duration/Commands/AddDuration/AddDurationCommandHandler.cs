﻿using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
using System.Security.Claims;


namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddDurationCommand, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(AddDurationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new AddDurationCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DurationDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);
            var duration = request.Adapt<Domain.Entities.Duration>();

            await unitOfWork.DurationRepository.AddAsync(duration);
            unitOfWork.CommitAsync();

            return Result<DurationDtoResponse>.Ok(duration.Adapt<DurationDtoResponse>());
        }
    }
}
