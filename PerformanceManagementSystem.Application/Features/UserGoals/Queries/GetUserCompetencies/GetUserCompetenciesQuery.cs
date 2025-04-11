using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserCompetencies
{
    public class GetUserCompetenciesQuery : IRequest<Result<UserCompetenciesDtoResponse>>
    {
    }
}
