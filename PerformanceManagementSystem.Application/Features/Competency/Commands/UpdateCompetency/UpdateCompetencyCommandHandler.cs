using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommandHandler : IRequestHandler<UpdateCompetencyCommand, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(UpdateCompetencyCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateCompetencyCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<CompetencyDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var addCompetencyDtoResponse = new CompetencyDtoResponse();
            return Result<CompetencyDtoResponse>.Ok(addCompetencyDtoResponse);
        }
    }
}
