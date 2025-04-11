using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserCompetencies
{
    public class GetUserCompetenciesQueryHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IRequestHandler<GetUserCompetenciesQuery, Result<UserCompetenciesDtoResponse>>
    {
        public async Task<Result<UserCompetenciesDtoResponse>> Handle(GetUserCompetenciesQuery request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<UserCompetenciesDtoResponse>.UnAuthorized("User not found");

            var uc = unitOfWork.UserGoalRepository.GetAllByUserID(user.ID).Result;
            if (uc == null)
                return Result<UserCompetenciesDtoResponse>.NotFound("User Not found");
            return Result<UserCompetenciesDtoResponse>.Ok(uc.Adapt<UserCompetenciesDtoResponse>());
        }
    }
}
