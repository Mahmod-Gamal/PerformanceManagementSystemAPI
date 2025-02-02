using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;


namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IHttpContextAccessor contextAccessor) : IRequestHandler<ChangePasswordCommand, Result<ChangePasswordDtoResponse>>
    {
        public async Task<Result<ChangePasswordDtoResponse>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<ChangePasswordDtoResponse>.UnAuthorized("User not found");

            if (!passwordManager.Verfiy(request.OldPassword, user.PasswordHash, user.PasswordSalt))
                return Result<ChangePasswordDtoResponse>.UnAuthorized("Current password is incorrect");

            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;

            await unitOfWork.CommitAsync();

            var changePasswordDtoResponse = new ChangePasswordDtoResponse
            {
                SuccessMessage = "Password updated successfully"
            };
            return Result<ChangePasswordDtoResponse>.Ok(changePasswordDtoResponse);
        }
    }
}
