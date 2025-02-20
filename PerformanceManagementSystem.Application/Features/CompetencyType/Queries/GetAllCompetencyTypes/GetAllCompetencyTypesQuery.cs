using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.CompetencyType.Queries.GetAllCompetencyTypes
{
    public class GetAllCompetencyTypesQuery : IRequest<Result<IEnumerable<CompetencyTypeDtoResponse>>>
    {
    }
}
