using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, Result<UserDtoResponse>>
    {
        public async Task<Result<UserDtoResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateUserCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<UserDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = unitOfWork.UserRepository.GetByIdAsync(request.ID).Result;
            if (user == null)
                return Result<UserDtoResponse>.NotFound("User Not found");

            request.Adapt(user);
            unitOfWork.CommitAsync();

            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
