using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommand : IRequest<Result<CompetencyDtoResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public int Level { get; set; }
        public int TypeID { get; set; }
    }
}
