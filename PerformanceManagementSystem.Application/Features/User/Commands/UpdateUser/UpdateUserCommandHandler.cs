using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserDtoResponse>>
    {
        public async Task<Result<UserDtoResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateUserCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<UserDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var addUserDtoResponse = new UserDtoResponse();
            return Result<UserDtoResponse>.Ok(addUserDtoResponse);
        }
    }
}
