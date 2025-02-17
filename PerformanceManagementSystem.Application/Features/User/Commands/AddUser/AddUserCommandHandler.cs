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

            emailService.SendEmail(user.Email, "Forget Password Request", $"Please Got to this Link to reset your Password : localhost:4200/set-password/{OTT}");

            await unitOfWork.UserRepository.AddAsync(user);
            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
