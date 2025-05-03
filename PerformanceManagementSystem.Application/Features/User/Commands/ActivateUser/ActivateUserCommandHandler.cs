using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.AddUser;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.User.Commands.ActivateUser
{
    public class ActivateUserCommandHandler(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor) : IRequestHandler<ActivateUserCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var adminId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var admin = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(adminId));
            if (admin is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
            if (admin.UserTypeId > 2)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User is not an Admin");
            var user = await unitOfWork.UserRepository.GetByIdAsync(request.ID);
            user.StatusID = 1; //Active

            return Result<AcknowledgmentDtoResponse>.Ok(new("User Activated"));
        }
    }
}
