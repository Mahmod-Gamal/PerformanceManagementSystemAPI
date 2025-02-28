﻿using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.UpdateUserObjectives
{
    public class UpdateUserObjectivesCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<UpdateUserObjectivesCommand, Result<UserObjectivesDtoResponse>>
    {
        public async Task<Result<UserObjectivesDtoResponse>> Handle(UpdateUserObjectivesCommand request, CancellationToken cancellationToken)
        {
            var userID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userID));
            if (user == null) 
                return Result<UserObjectivesDtoResponse>.NotFound("User Not Found");
            var userGoals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year);
            if (userGoals == null)
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    StageID = 1
                };
            userGoals.UserObjectives = request.UserObjectives.Select(x => x.Adapt<Domain.Entities.UserObjective>()).ToList();

            return Result<UserObjectivesDtoResponse>.Ok(userGoals.Adapt<UserObjectivesDtoResponse>());
        }
    }
}
