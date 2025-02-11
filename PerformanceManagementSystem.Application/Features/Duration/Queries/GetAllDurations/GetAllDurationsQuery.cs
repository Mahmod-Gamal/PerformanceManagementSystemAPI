using MediatR;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations
{
    public class GetAllDurationsQuery : IRequest<Result<IEnumerable<DurationDtoResponse>>>
    {
    }
}
