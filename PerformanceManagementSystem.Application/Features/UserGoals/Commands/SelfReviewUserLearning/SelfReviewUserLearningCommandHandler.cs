﻿using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning
{
    public class SelfReviewUserLearningCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SelfReviewUserLearningCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(SelfReviewUserLearningCommand request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
            var duration = await unitOfWork.DurationRepository.GetByIdAsync(user.MidYearDurationID);
            if (duration.Start >= DateOnly.FromDateTime(DateTime.Now)
                || duration.End <= DateOnly.FromDateTime(DateTime.Now))
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("Out of Duration");
            var goals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year);

            goals.UserLearnings.ToList().ForEach(ul => {
            ul.Review = request.userLearnings.Where(x => x.ID == ul.ID).Select(x => x.Review).FirstOrDefault();
            });

            return Result<AcknowledgmentDtoResponse>.Ok(new AcknowledgmentDtoResponse("Saved"));
        }
    }
}
