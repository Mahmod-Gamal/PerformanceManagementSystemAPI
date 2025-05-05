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


            var UserCoreCompetencies = new List<UserCompetencyDto>();
            var UserFunctionalCompetencies = new List<UserCompetencyDto>();


            if (goal is not null && goal.UserCompetencies != null && goal.UserCompetencies.Any())
            {
                UserCoreCompetencies = goal.UserCompetencies.Where(uc => uc.Competency.CompetenciesTypeID == 1).Adapt<List<UserCompetencyDto>>();
                UserFunctionalCompetencies = goal.UserCompetencies.Where(uc => uc.Competency.CompetenciesTypeID == 2).Adapt<List<UserCompetencyDto>>();
            }
            else
            {
                // Fetch all competencies and return default values
                var allCompetencies = await unitOfWork.CompetencyRepository.GetAllAsync();

                UserCoreCompetencies = allCompetencies.Where(c => c.CompetenciesTypeID == 1).Select(c => new UserCompetencyDto
                {
                    CompetencyID = c.ID,
                    CompetencyName = c.Name,
                    CurrentLevel = null,
                    ExpectedLevel = null,
                    Rating = null,
                    ManagerRating = null
                }).ToList();
                UserFunctionalCompetencies = allCompetencies.Where(c => c.CompetenciesTypeID == 2).Select(c => new UserCompetencyDto
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
                UserCoreCompetencies = UserCoreCompetencies,
                UserFunctionalCompetencies = UserFunctionalCompetencies,
                UserLearnings = goal?.UserLearnings?.Adapt<List<UserLearningDto>>() ?? new(),
                UserObjectives = goal?.UserObjectives?.Adapt<List<UserObjectiveDto>>() ?? new(),
                ObjectivesScore = goal?.UserObjectives?.Select(uo => (uo.Weight ?? 0) * (uo.Achieved ?? 0) / 100).Sum(),
                // UserTrainings = goal?.UserTrainings?.Adapt<List<UserTrainingDto>>() ?? new(),
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
