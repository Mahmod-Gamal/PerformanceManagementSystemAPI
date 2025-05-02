using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies
{
    public class SetUserCompetenciesCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<SetUserCompetenciesCommand, Result<UserCompetenciesDtoResponse>>
    {
        public async Task<Result<UserCompetenciesDtoResponse>> Handle(SetUserCompetenciesCommand request, CancellationToken cancellationToken)
        {
            var userID = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userID));
            if (user == null)
                return Result<UserCompetenciesDtoResponse>.NotFound("User Not Found");
            var userGoal = await unitOfWork.UserGoalRepository.GetByUserID(user.ID, DateTime.Now.Year);
            if (userGoal == null)
            {
                userGoal = new Domain.Entities.UserGoal()
                {
                    UserID = user.ID,
                    Year = DateTime.Now.Year,
                    StageID = 1
                };
                await unitOfWork.UserGoalRepository.AddAsync(userGoal);
            }

            //userGoal.UserCompetencies = request.Competenciess.Select(x => x.Adapt<Domain.Entities.UserCompetency>()).ToList();

            return Result<UserCompetenciesDtoResponse>.Ok(userGoal.Adapt<UserCompetenciesDtoResponse>());
        }
    }
}
