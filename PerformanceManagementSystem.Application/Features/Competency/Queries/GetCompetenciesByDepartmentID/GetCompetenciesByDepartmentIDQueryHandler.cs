using MediatR;
using Mapster;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetBehavioralCompetencies;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetenciesByDepartmentID
{
    public class GetCompetenciesByDepartmentIDQueryHandler(IUnitOfWork unitOfWork) :IRequestHandler<GetCompetenciesByDepartmentIDQuery, Result<IEnumerable<CompetencyDtoResponse>>>
    {
        public async Task<Result<IEnumerable<CompetencyDtoResponse>>> Handle(GetCompetenciesByDepartmentIDQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<CompetencyDtoResponse>>.Ok(unitOfWork.CompetencyRepository.GetCompetenciesByDepartment(request.DepartmentID).Result.Adapt<IEnumerable<CompetencyDtoResponse>>());

        }
    }
}
