using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCompetencyCommand, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(AddCompetencyCommand request, CancellationToken cancellationToken)
        {
            var competency = request.Adapt<Domain.Entities.Competency>();
            await unitOfWork.CompetencyRepository.AddAsync(competency);
            return Result<CompetencyDtoResponse>.Ok(competency.Adapt<CompetencyDtoResponse>());
        }
    }
}
