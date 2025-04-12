using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserGoals
{
    public class GetUserGoalsByIDQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        : IRequestHandler<GetUserGoalsByIDQuery, Result<UserGoalsDtoResponse>>
    {
        public async Task<Result<UserGoalsDtoResponse>> Handle(GetUserGoalsByIDQuery request, CancellationToken cancellationToken)
        {
            var managerId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerId))
                return Result<UserGoalsDtoResponse>.UnAuthorized("User not authenticated");

            var manager = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(managerId));
            if (manager is null)
                return Result<UserGoalsDtoResponse>.NotFound("User not found");
            if (manager.UserTypeId != 3)
                return Result<UserGoalsDtoResponse>.NotFound("User is not a manager");

            var user = await unitOfWork.UserRepository.GetByIdAsync(request.ID);
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
                    Review = null,
                    ManagerReview = null
                }).ToList();
            }

            var response = new UserGoalsDtoResponse
            {
                UserGoal = goal?.Adapt<UserGoalDto>(),
                UserCompetencies = userCompetencies,
                UserLearnings = goal?.UserLearnings?.Adapt<List<UserLearningDto>>() ?? new(),
                UserObjectives = goal?.UserObjectives?.Adapt<List<UserObjectiveDto>>() ?? new(),
                UserTrainings = goal?.UserTrainings?.Adapt<List<UserTrainingDto>>() ?? new()
            };

            return Result<UserGoalsDtoResponse>.Ok(response);
        }

    }
}
