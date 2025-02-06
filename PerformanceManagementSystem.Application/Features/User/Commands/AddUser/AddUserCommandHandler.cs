using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;


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

          var addUserDtoResponse = new UserDtoResponse();
            return Result<UserDtoResponse>.Ok(addUserDtoResponse);
        }
    }
}
