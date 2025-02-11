using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.Login
{

    public class LoginCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginDtoResponse>>
    {
        public async Task<Result<LoginDtoResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var Validator = new LoginCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<LoginDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);
            var user = await unitOfWork.UserRepository.GetUser(request.EmailOrUsername);
            if (user is null) return Result<LoginDtoResponse>.UnAuthorized("Invalid username or password");

            if (passwordManager.Verfiy(request.Password, user.PasswordHash, user.PasswordSalt))
            {

                user.OTP = null;
                var loginDtoResponse = new LoginDtoResponse
                {
                    Token = jwtProvider.GenerateToken(user),
                    UserId = user.ID,
                    Username = user.UserName,
                    UserType = user.UserType.Name,
                    UserTypeId = user.UserTypeId,
                };


                unitOfWork.CommitAsync();
                return Result<LoginDtoResponse>.Ok(loginDtoResponse);
            }
            return Result<LoginDtoResponse>.UnAuthorized("Invalid username or password");
        }
    }
}
