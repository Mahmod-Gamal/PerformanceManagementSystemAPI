using MediatR;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies
{
    public class GetAllCompetenciesQuery : IRequest<Result<IEnumerable<CompetencyDtoResponse>>>
    {
    }
}
