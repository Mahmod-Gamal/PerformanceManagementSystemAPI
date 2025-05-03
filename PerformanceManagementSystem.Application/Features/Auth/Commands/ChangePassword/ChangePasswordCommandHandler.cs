using MediatR;
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
            var tokenVersion = Guid.Parse(contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.UserData)?.Value);
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null || user.StatusID != 1)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
            if (user.TokenVersion != tokenVersion)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("Token Expired,Login again");

            if (!passwordManager.Verfiy(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("Current password is incorrect");

            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.OTP = null;
            user.TokenVersion = Guid.NewGuid();

            await unitOfWork.CommitAsync();

            return Result<AcknowledgmentDtoResponse>.Ok(new("Password updated successfully"));
        }
    }
}
