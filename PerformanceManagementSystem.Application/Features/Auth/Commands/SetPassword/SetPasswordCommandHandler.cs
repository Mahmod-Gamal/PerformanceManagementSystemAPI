using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{


    public class SetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IHttpContextAccessor contextAccessor) : IRequestHandler<SetPasswordCommand, Result<SetPasswordDtoResponse>>
    {

        public async Task<Result<SetPasswordDtoResponse>> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var Validator = new SetPasswordCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<SetPasswordDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<SetPasswordDtoResponse>.UnAuthorized("User not found");
     
            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.ShouldChangePassword = false;

            await unitOfWork.CommitAsync();

            var setPasswordDtoResponse = new SetPasswordDtoResponse()
            {
                SuccessMessage = "Password updated successfully"
            };
            return Result<ChangePasswordDtoResponse>.Ok(setPasswordDtoResponse);
        }
    }
}
