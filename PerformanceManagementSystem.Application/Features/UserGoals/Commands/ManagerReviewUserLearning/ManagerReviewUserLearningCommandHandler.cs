using MediatR;
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

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning
{
    public class ManagerReviewUserLearningCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<ManagerReviewUserLearningCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(ManagerReviewUserLearningCommand request, CancellationToken cancellationToken)
        {

            var managerID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Manager = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(managerID));
            if (Manager is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");
            if (Manager.UserTypeId != 3)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User is not a Manager");

            var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserID);
            if (user is null)
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("User not found");

            var duration = await unitOfWork.DurationRepository.GetByIdAsync(user.EndYearDurationID);
            if (duration.Start >= DateOnly.FromDateTime(DateTime.Now)
                || duration.End <= DateOnly.FromDateTime(DateTime.Now))
                return Result<AcknowledgmentDtoResponse>.UnAuthorized("Out of Duration");
            var goals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year,false);

            goals.UserLearnings.ToList().ForEach(ul =>
            {
                ul.ManagerRating = request.userLearnings.Where(x => x.ID == ul.ID).Select(x => x.Rating).FirstOrDefault();
                ul.ManagerComment = request.userLearnings.Where(x => x.ID == ul.ID).Select(x => x.Comment).FirstOrDefault();

                var userTrainings = request.userLearnings.Where(x => x.ID == ul.ID).Select(x => x.userTrainings).FirstOrDefault();
                ul.UserTrainings.ToList().ForEach(ut =>
                {
                    ut.ManagerRating = userTrainings.Where(x => x.ID == ut.ID).Select(x => x.Rating).FirstOrDefault();

                    ut.ManagerComment = userTrainings.Where(x => x.ID == ut.ID).Select(x => x.Comment).FirstOrDefault();

                });
            });

            return Result<AcknowledgmentDtoResponse>.Ok(new AcknowledgmentDtoResponse("Saved"));
        }
    }
}
