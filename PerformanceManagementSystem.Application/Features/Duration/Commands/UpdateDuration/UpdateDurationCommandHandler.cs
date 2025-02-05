using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration
{
    public class UpdateDurationCommandHandler : IRequestHandler<UpdateDurationCommand, Result<DurationDtoResponse>>
    {
        public async Task<Result<DurationDtoResponse>> Handle(UpdateDurationCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateDurationCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<DurationDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var addDurationDtoResponse = new DurationDtoResponse();
            return Result<DurationDtoResponse>.Ok(addDurationDtoResponse);
        }
    }
}
