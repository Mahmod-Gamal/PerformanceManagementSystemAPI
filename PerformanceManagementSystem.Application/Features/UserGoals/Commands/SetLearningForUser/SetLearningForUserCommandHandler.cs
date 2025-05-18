using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetLearningForUser
{
    public class SetLearningForUserCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetLearningForUserCommand, Result<UserLearningDtoResponse>>
    {
        public async Task<Result<UserLearningDtoResponse>> Handle(SetLearningForUserCommand request, CancellationToken cancellationToken)
        {
            var adminID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var admin = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(adminID));
            if (admin == null)
                return Result<UserLearningDtoResponse>.NotFound("User Not Found");
            if (admin.UserTypeId > 2)
                return Result<UserLearningDtoResponse>.UnAuthorized("User is Not an Admin");

            var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserID);
            if (user == null)
                return Result<UserLearningDtoResponse>.NotFound("User Not Found");

            var userGoals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year, true);
            if (userGoals == null)
            {
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    ByAdmin = true
                };
                await unitOfWork.UserGoalRepository.AddAsync(userGoals);
            }

            userGoals.UserLearnings = request.Learnings.Adapt<List<Domain.Entities.UserLearning>>();
            return Result<UserLearningDtoResponse>.Ok(userGoals.Adapt<UserLearningDtoResponse>());
        }
    }
}
