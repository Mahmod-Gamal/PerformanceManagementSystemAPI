using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID
{
    public class GetCompetencyByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCompetencyByIDQuery, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(GetCompetencyByIDQuery request, CancellationToken cancellationToken)
        {
            var competency = unitOfWork.CompetencyRepository.GetCompetencyWithDetails(request.ID).Result;
            if (competency == null)
                return Result<CompetencyDtoResponse>.NotFound("Competency Not found");
            return Result<CompetencyDtoResponse>.Ok(competency.Adapt<CompetencyDtoResponse>());
        }
    }
}
