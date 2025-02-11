using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddUserCommand, Result<UserDtoResponse>>
    {
        public async Task<Result<UserDtoResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var Validator = new AddUserCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<UserDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = request.Adapt<Domain.Entities.User>();

            await unitOfWork.UserRepository.AddAsync(user);
            unitOfWork.CommitAsync();

            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
