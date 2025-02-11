using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.DeleteCompetency
{
    public class DeleteCompetencyCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
