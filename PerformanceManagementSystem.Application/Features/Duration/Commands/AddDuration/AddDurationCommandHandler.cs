using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Domain.Entities;


namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddDurationCommand, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(AddDurationCommand request, CancellationToken cancellationToken)
        {
            var duration = request.Adapt<DomainDuration>();
            await unitOfWork.DurationRepository.AddAsync(duration);
            return Result<DurationDtoResponse>.Ok(duration.Adapt<DurationDtoResponse>());
        }
    }
}
