using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompetencyCommand, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(UpdateCompetencyCommand request, CancellationToken cancellationToken)
        {
            var competency = unitOfWork.CompetencyRepository.GetCompetencyWithDetails(request.ID).Result;
            if (competency == null)
                return Result<CompetencyDtoResponse>.NotFound("Competency Not found");
            request.Adapt(competency);
            //await unitOfWork.CommitAsync(cancellationToken);
            return Result<CompetencyDtoResponse>.Ok(competency.Adapt<CompetencyDtoResponse>());
        }
    }
}
