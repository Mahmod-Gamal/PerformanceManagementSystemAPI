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
            var validator = new ForgetPasswordCommandValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = await unitOfWork.UserRepository.GetUserByEmail(request.Email);
            if (user is null || user.StatusID != 1) return Result<AcknowledgmentDtoResponse>.NotFound("Email not found");

            user.OTP = passwordManager.GenerateRandomOTP();
            string OTT = passwordManager.EncodeOTT(user.UserName, user.OTP);

            await unitOfWork.CommitAsync(); // Ensure changes are saved before sending the email

            // Email template
            string emailBody = $@"
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Password Reset</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                margin: 0;
                padding: 0;
            }}
            .container {{
                max-width: 600px;
                margin: 20px auto;
                background: #ffffff;
                padding: 20px;
                border-radius: 8px;
                box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            }}
            h2 {{
                color: #333;
                text-align: center;
            }}
            p {{
                font-size: 16px;
                color: #666;
                text-align: center;
            }}
            .btn {{
                display: block;
                width: 200px;
                margin: 20px auto;
                padding: 12px;
                text-align: center;
                color: #ffffff;
                border-color: #50cd89;
                background-color: #50cd89;
                text-decoration: none;
                border-radius: 5px;
                font-size: 16px;
            }}
            .btn:hover {{
                background: #50cd89;
            }}
            .footer {{
                margin-top: 20px;
                text-align: center;
                font-size: 12px;
                color: #999;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h2>Password Reset Request</h2>
            <p>You recently requested to reset your password. Click the button below to set a new password:</p>
            <a href='http://localhost:4200/set-password/{OTT}' class='btn'>Reset Password</a>
            <p>If you did not request this, please ignore this email.</p>
            <div class='footer'>
                &copy; 2025 DEFI. All Rights Reserved.
            </div>
        </div>
    </body>
    </html>";

            emailService.SendEmail(user.Email, "Set Your New Password", emailBody);

            return Result<AcknowledgmentDtoResponse>.Ok(new("Check Your Mail"));
        }

    }

}
