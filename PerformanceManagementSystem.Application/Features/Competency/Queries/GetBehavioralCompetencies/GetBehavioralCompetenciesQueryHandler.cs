using MediatR;
using Mapster;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetBehavioralCompetencies
{
    public class GetBehavioralCompetenciesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetBehavioralCompetenciesQuery, Result<IEnumerable<CompetencyDtoResponse>>>
    {
        public async Task<Result<IEnumerable<CompetencyDtoResponse>>> Handle(GetBehavioralCompetenciesQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<CompetencyDtoResponse>>.Ok(unitOfWork.CompetencyRepository.GetBehavioralCompetencies().Result.Adapt<IEnumerable<CompetencyDtoResponse>>());

        }
    }
}
