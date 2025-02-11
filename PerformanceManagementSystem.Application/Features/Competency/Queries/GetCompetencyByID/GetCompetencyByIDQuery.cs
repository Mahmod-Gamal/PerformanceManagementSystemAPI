using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID
{
    public class GetCompetencyByIDQuery : IRequest<Result<CompetencyDtoResponse>>
    {
        public int ID { get; set; }
    }
}
