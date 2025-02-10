using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;


namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager,IEmailService emailService) : IRequestHandler<ForgetPasswordCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var Validator = new ForgetPasswordCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = await unitOfWork.UserRepository.GetUserByEmail(request.Email);
            if (user is null) return Result<AcknowledgmentDtoResponse>.NotFound("Email not found");
            user.OTP = passwordManager.GenerateRandomOTP();

            unitOfWork.CommitAsync();

            //emailService.SendEmail(user.Email, "Forget Password Request", $"Your OTP is : {user.OTP}");
            emailService.SendEmail("mahmoud.s.marwad@gmail.com", "Forget Password Request", $"Your OTP is : {user.OTP}");

            var acknowledgmentDtoResponse = new AcknowledgmentDtoResponse()
            {
                Message = "OTP Sent to Your Mail"
            };
            return Result<AcknowledgmentDtoResponse>.Ok(acknowledgmentDtoResponse);
        }
    }

}
