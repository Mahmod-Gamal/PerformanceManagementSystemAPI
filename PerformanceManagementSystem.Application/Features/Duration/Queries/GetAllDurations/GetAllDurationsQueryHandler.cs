using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations
{
    public class GetAllDurationsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllDurationsQuery, Result<IEnumerable<DurationDtoResponse>>>
    {
        public async Task<Result<IEnumerable<DurationDtoResponse>>> Handle(GetAllDurationsQuery request, CancellationToken cancellationToken)
        {
            var durations = await unitOfWork.DurationRepository.GetAllAsync();
            return Result<IEnumerable<DurationDtoResponse>>.Ok(durations.Adapt<IEnumerable<DurationDtoResponse>>());
        }
    }
}
