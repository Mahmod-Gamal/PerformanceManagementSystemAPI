using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration
{
    public class UpdateDurationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateDurationCommand, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(UpdateDurationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateDurationCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DurationDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);
            var duration = unitOfWork.DurationRepository.GetByIdAsync(request.ID).Result;
            if (duration == null)
                return Result<DurationDtoResponse>.NotFound("Duration Not found");

            request.Adapt(duration);
            unitOfWork.CommitAsync();

            return Result<DurationDtoResponse>.Ok(duration.Adapt<DurationDtoResponse>());
        }
    }
}
