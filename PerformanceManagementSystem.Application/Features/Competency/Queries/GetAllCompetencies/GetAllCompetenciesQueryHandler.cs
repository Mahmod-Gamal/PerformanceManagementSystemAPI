using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies
{
    public class GetAllCompetenciesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCompetenciesQuery, Result<IEnumerable<CompetencyDtoResponse>>>
    {
        public async Task<Result<IEnumerable<CompetencyDtoResponse>>> Handle(GetAllCompetenciesQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<CompetencyDtoResponse>>.Ok(unitOfWork.CompetencyRepository.GetAllAsync().Result.Adapt<IEnumerable<CompetencyDtoResponse>>());

        }
    }
}
