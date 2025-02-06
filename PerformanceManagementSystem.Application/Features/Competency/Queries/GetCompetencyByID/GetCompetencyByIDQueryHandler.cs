using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID
{
    public class GetCompetencyByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCompetencyByIDQuery, Result<CompetencyDtoResponse>>
    {
        public Task<Result<CompetencyDtoResponse>> Handle(GetCompetencyByIDQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
