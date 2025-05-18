using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives
{
    public class SetUserObjectivesCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetUserObjectivesCommand, Result<UserObjectivesDtoResponse>>
    {
        public async Task<Result<UserObjectivesDtoResponse>> Handle(SetUserObjectivesCommand request, CancellationToken cancellationToken)
        {
            var userID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userID));
            if (user == null) 
                return Result<UserObjectivesDtoResponse>.NotFound("User Not Found");
            var userGoals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year,false);
            if (userGoals == null)
            {
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    ByAdmin = false
                };
                await unitOfWork.UserGoalRepository.AddAsync(userGoals);
            }
            userGoals.UserObjectives = request.UserObjectives.Select(x => x.Adapt<Domain.Entities.UserObjective>()).ToList();
            return Result<UserObjectivesDtoResponse>.Ok(userGoals.Adapt<UserObjectivesDtoResponse>());
        }
    }
}
