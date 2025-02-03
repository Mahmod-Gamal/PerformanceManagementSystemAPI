using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.Login;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;


namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager,IEmailService emailService) : IRequestHandler<ForgetPasswordCommand, Result<ForgetPasswordDtoResponse>>
    {
        public async Task<Result<ForgetPasswordDtoResponse>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var Validator = new ForgetPasswordCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<ForgetPasswordDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = await unitOfWork.UserRepository.GetUserByEmail(request.Email);
            if (user is null) return Result<ForgetPasswordDtoResponse>.NotFound("Email not found");
            var newPassword = "12345678";

            passwordManager.CreatePasswordHash(newPassword, out var newPasswordHash, out var newPasswordSalt);
            user.PasswordHash = newPasswordHash;
            user.PasswordSalt = newPasswordSalt;
            user.ShouldChangePassword = true;

            unitOfWork.CommitAsync();

            // Send Mail With New Password
            //emailService.SendEmail(user.Email, "Forget Password Request", $"Your OTP is : {newPassword}");

            emailService.SendEmail("mahmoud.s.marwad@gmail.com", "Forget Password Request", $"Your OTP is : {newPassword}");

            var forgetPasswordDtoResponse = new ForgetPasswordDtoResponse()
            {
                Message = "Forgetted Password"
            };
            return Result<ForgetPasswordDtoResponse>.Ok(forgetPasswordDtoResponse);
        }
    }

}
