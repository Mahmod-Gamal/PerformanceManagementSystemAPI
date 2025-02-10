using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;


namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID
{
    public class GetDurationByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDurationByIDQuery, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(GetDurationByIDQuery request, CancellationToken cancellationToken)
        {
            var duration = unitOfWork.DurationRepository.GetByIdAsync(request.ID).Result;
            if (duration == null)
                return Result<DurationDtoResponse>.NotFound("Duration Not found");

            request.Adapt(duration);

            return Result<DurationDtoResponse>.Ok(duration.Adapt<DurationDtoResponse>());
        }
    }
}
