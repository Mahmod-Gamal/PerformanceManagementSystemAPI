using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var Validator = new DeleteUserCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var user = unitOfWork.UserRepository.GetByIdAsync(request.ID).Result;
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("User Not Found");

            unitOfWork.UserRepository.Remove(user);

            return Result<AcknowledgmentDtoResponse>.Ok(new("Deleted Successfully"));
        }
    }
}
