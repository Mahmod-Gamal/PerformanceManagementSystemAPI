using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.DeleteCompetency
{
    public class DeleteCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompetencyCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteCompetencyCommand request, CancellationToken cancellationToken)
        {
            var competency = unitOfWork.CompetencyRepository.GetByIdAsync(request.ID).Result;
            if (competency is null)
                return Result<AcknowledgmentDtoResponse>.NotFound("Competency Not Found");
            unitOfWork.CompetencyRepository.Remove(competency);
            //await unitOfWork.CommitAsync(cancellationToken);
            return Result<AcknowledgmentDtoResponse>.Ok(new("Deleted Successfully"));
        }
    }
}
