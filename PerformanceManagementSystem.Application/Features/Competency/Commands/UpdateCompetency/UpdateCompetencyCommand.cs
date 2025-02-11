using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommand : IRequest<Result<CompetencyDtoResponse>>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }
        public int Level { get; set; }
        public int TypeID { get; set; }
        public int StatusID { get; set; }
    }
}
