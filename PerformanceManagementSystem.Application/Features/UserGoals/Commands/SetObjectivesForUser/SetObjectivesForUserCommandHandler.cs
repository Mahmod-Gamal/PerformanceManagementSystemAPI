using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetObjectivesForUser
{
    public class SetObjectivesForUserCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetObjectivesForUserCommand, Result<UserObjectivesDtoResponse>>
    {
        public async Task<Result<UserObjectivesDtoResponse>> Handle(SetObjectivesForUserCommand request, CancellationToken cancellationToken)
        {
            var adminID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var admin = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(adminID));
            if (admin == null)
                return Result<UserObjectivesDtoResponse>.NotFound("User Not Found");
            if (admin.UserTypeId > 2)
                return Result<UserObjectivesDtoResponse>.UnAuthorized("User is Not an Admin");

            var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserID);
            if (user == null)
                return Result<UserObjectivesDtoResponse>.NotFound("User Not Found");

            var userGoals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year, true);
            if (userGoals == null)
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    ByAdmin = true
                };

            userGoals.UserObjectives = request.UserObjectives.Select(x => x.Adapt<Domain.Entities.UserObjective>()).ToList();
            return Result<UserObjectivesDtoResponse>.Ok(userGoals.Adapt<UserObjectivesDtoResponse>());
        }
    }
}
