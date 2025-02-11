using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompetencyCommand, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(UpdateCompetencyCommand request, CancellationToken cancellationToken)
        {
            var Validator = new UpdateCompetencyCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<CompetencyDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);
          
            var competency = unitOfWork.CompetencyRepository.GetByIdAsync(request.ID).Result;
            if (competency == null)
                return Result<CompetencyDtoResponse>.NotFound("Competency Not found");

            request.Adapt(competency);
            unitOfWork.CommitAsync();

            return Result<CompetencyDtoResponse>.Ok(competency.Adapt<CompetencyDtoResponse>());
        }
    }
}
