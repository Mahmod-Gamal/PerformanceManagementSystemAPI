using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserTrainings
{
    public class SetUserTrainingsCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetUserTrainingsCommand, Result<UserTrainingsDtoResponse>>
    {
        public async Task<Result<UserTrainingsDtoResponse>> Handle(SetUserTrainingsCommand request, CancellationToken cancellationToken)
        {
            var userID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userID));
            if (user == null)
                return Result<UserTrainingsDtoResponse>.NotFound("User Not Found");
            var userGoals = new Domain.Entities.UserGoal(); // await unitOfWork.UserLearningRepostiory.GetByIdAsync(request.);
            if (userGoals == null)
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    StageID = 1
                };
            userGoals.UserTrainings = request.Trainings.Select(x => x.Adapt<Domain.Entities.UserTraining>()).ToList();

            return Result<UserTrainingsDtoResponse>.Ok(userGoals.Adapt<UserTrainingsDtoResponse>());
        }
    }
}
