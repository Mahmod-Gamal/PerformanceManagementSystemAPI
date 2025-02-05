﻿using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;


namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IHttpContextAccessor contextAccessor) : IRequestHandler<ChangePasswordCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var Validator = new ChangePasswordCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");

            if (!passwordManager.Verfiy(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("Current password is incorrect");

            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            await unitOfWork.CommitAsync();

            var acknowledgmentDtoResponse = new AcknowledgmentDtoResponse
            {
                Message = "Password updated successfully"
            };
            return Result<AcknowledgmentDtoResponse>.Ok(acknowledgmentDtoResponse);
        }
    }
}
