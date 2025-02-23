using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler(IUnitOfWork unitOfWork,IPasswordManager passwordManager, IEmailService emailService) : IRequestHandler<AddUserCommand, Result<UserDtoResponse>>
    {
        public async Task<Result<UserDtoResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {            
            var user = request.Adapt<Domain.Entities.User>();
            user.OTP = passwordManager.GenerateRandomOTP();
            string OTT = passwordManager.EncodeOTT(user.UserName, user.OTP);
            user.TokenVersion = new Guid();
            string emailBody = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Password Reset</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 600px;
            margin: 20px auto;
            background: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            color: #333;
            text-align: center;
        }
        p {
            font-size: 16px;
            color: #666;
            text-align: center;
        }
        .btn {
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
        }
        .btn:hover {
            background: #0056b3;
        }
        .footer {
            margin-top: 20px;
            text-align: center;
            font-size: 12px;
            color: #999;
        }
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


            await unitOfWork.UserRepository.AddAsync(user);
            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
