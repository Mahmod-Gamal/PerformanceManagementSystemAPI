using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserGoals
{
    public class GetUserGoalsQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        : IRequestHandler<GetUserGoalsQuery, Result<UserGoalsDtoResponse>>
    {
        public async Task<Result<UserGoalsDtoResponse>> Handle(GetUserGoalsQuery request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Result<UserGoalsDtoResponse>.UnAuthorized("User not authenticated");

            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<UserGoalsDtoResponse>.NotFound("User not found");

            var currentYear = DateTime.UtcNow.Year;

            var goal = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, currentYear);


            var userCompetencies = new List<UserCompetencyDto>();

            if (goal is not null && goal.UserCompetencies != null && goal.UserCompetencies.Any())
            {
                userCompetencies = goal.UserCompetencies.Adapt<List<UserCompetencyDto>>();
            }
            else
            {
                // Fetch all competencies and return default values
                var allCompetencies = await unitOfWork.CompetencyRepository.GetAllAsync();

                userCompetencies = allCompetencies.Select(c => new UserCompetencyDto
                {
                    CompetencyID = c.ID,
                    CompetencyName = c.Name,
                    CurrentLevel = null,
                    ExpectedLevel = null,
                    Rating = null,
                    ManagerRating = null
                }).ToList();
            }

            var response = new UserGoalsDtoResponse
            {
                UserGoal = goal?.Adapt<UserGoalDto>(),
                UserCompetencies = userCompetencies,
                UserLearnings = goal?.UserLearnings?.Adapt<List<UserLearningDto>>() ?? new(),
                UserObjectives = goal?.UserObjectives?.Adapt<List<UserObjectiveDto>>() ?? new(),
                UserTrainings = goal?.UserTrainings?.Adapt<List<UserTrainingDto>>() ?? new(),
                //CanSetGoals = goal?.User?.MidYearDuration?.Start > DateOnly.FromDateTime(DateTime.Now)
                //&& goal?.User?.EndYearDuration?.Start > DateOnly.FromDateTime(DateTime.Now),
                //CanSelfReview = DateOnly.FromDateTime(DateTime.Now) >= goal?.User?.MidYearDuration?.Start
                //&& DateOnly.FromDateTime(DateTime.Now) <= goal?.User?.MidYearDuration?.End,
                //CanManagerReview = DateOnly.FromDateTime(DateTime.Now) >= goal?.User?.EndYearDuration?.Start
                //&& DateOnly.FromDateTime(DateTime.Now) <= goal?.User?.EndYearDuration?.End,
            };

            return Result<UserGoalsDtoResponse>.Ok(response);
        }

    }
}
