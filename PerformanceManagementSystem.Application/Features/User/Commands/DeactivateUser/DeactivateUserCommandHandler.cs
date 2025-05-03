using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.User.Commands.DeactivateUser
{
    public class DeactivateUserCommandHandler(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor) : IRequestHandler<DeactivateUserCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            var adminId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var admin = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(adminId));
            if (admin is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
            if (admin.UserTypeId > 2)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User is not an Admin");
            var user = await unitOfWork.UserRepository.GetByIdAsync(request.ID);
            user.StatusID = 2; //Deactive

            return Result<AcknowledgmentDtoResponse>.Ok(new("User Deactivated"));
        }
    }
}
