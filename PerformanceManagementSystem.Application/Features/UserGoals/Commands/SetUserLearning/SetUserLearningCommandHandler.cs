using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning
{
    public class SetUserLearningCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetUserLearningCommand, Result<UserLearningDtoResponse>>
    {
        public async Task<Result<UserLearningDtoResponse>> Handle(SetUserLearningCommand request, CancellationToken cancellationToken)
        {
            var userID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userID));
            if (user == null)
                return Result<UserLearningDtoResponse>.NotFound("User Not Found");
            var userGoals = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year, false);
            if (userGoals == null)
                userGoals = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    ByAdmin = false
                };
            userGoals.UserLearnings = request.Learnings.Adapt<List<Domain.Entities.UserLearning>>();
            return Result<UserLearningDtoResponse>.Ok(userGoals.Adapt<UserLearningDtoResponse>());
        }
    }
}
