using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Features.Auth.Commands.Login;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;


namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager) : IRequestHandler<ForgetPasswordCommand, Result<ForgetPasswordDtoResponse>>
    {
        public async Task<Result<ForgetPasswordDtoResponse>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository.GetUser(request.Email);
            if (user is null) return Result<ForgetPasswordDtoResponse>.NotFound("Invalid username or password");
            var newPassword = "12345678";

            passwordManager.CreatePasswordHash(newPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.ShouldChangePassword = true;

            // Send Mail With New Password

            var forgetPasswordDtoResponse = new ForgetPasswordDtoResponse()
            {
                Message = "Forgetted Password"
            };
            return Result<ForgetPasswordDtoResponse>.Ok(forgetPasswordDtoResponse);
        }
    }

}
