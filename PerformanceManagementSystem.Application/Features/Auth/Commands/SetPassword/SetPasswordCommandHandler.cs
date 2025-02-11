using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

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
            var (username,otp) = passwordManager.DecodeOTT(request.OTT);
            var user = await unitOfWork.UserRepository.GetUser(username);
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
     
            if (user.OTP != otp)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("OTP is not Correct");

            passwordManager.CreatePasswordHash(request.NewPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.OTP = null;
            user.TokenVersion = Guid.NewGuid();

            await unitOfWork.CommitAsync();

            return Result<AcknowledgmentDtoResponse>.Ok(new("Password Updated Successfully"));
        }
    }
}
