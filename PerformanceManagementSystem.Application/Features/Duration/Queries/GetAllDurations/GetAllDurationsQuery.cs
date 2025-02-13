using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Common.Interfaces;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations
{
    public class GetAllDurationsQuery : IQuery<Result<IEnumerable<DurationDtoResponse>>>
    {
    }
}
