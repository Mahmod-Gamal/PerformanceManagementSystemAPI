using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.CompetencyType.Queries.GetAllCompetencyTypes
{
    public class GetAllCompetencyTypesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCompetencyTypesQuery, Result<IEnumerable<CompetencyTypeDtoResponse>>>
    {
        public async Task<Result<IEnumerable<CompetencyTypeDtoResponse>>> Handle(GetAllCompetencyTypesQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<CompetencyTypeDtoResponse>>.Ok(unitOfWork.CompetencyTypeRepository.GetCompetencyTypes().Result.Adapt<IEnumerable<CompetencyTypeDtoResponse>>());

        }
    }
}
