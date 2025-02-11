using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID
{
    public class GetDurationByIDQuery : IRequest<Result<DurationDtoResponse>>
    {
        public int ID { get; set; }
    }
}
