using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
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


    public class SetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IHttpContextAccessor contextAccessor) : IRequestHandler<SetPasswordCommand, Result<AcknowledgmentDtoResponse>>
    {

        public async Task<Result<AcknowledgmentDtoResponse>> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var Validator = new SetPasswordCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            //var tokenVersion = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.UserData)?.Value;
            var user = await unitOfWork.UserRepository.GetUser(request.EmailOrUsername);
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
     
            if (user.OTP != request.OTP)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("OTP is not Correct");

            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.OTP = null;
            user.TokenVersion = Guid.NewGuid();

            await unitOfWork.CommitAsync();

            var acknowledgmentDtoResponse = new AcknowledgmentDtoResponse()
            {
                Message = "Password updated successfully"
            };
            return Result<AcknowledgmentDtoResponse>.Ok(acknowledgmentDtoResponse);
        }
    }
}
