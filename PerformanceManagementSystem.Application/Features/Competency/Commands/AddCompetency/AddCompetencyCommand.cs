using MediatR;
using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommand : ICommand<Result<CompetencyDtoResponse>>
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public string BasicLevelDescription { get; set; }  // Level 1 - Basic
        public string ProficientLevelDescription { get; set; }  // Level 2 - Proficient
        public string AdvancedLevelDescription { get; set; }  // Level 3 - Advanced
        public string ExpertLevelDescription { get; set; }  // Level 4 - Expert
        public int CompetenciesTypeID { get; set; }
    }
}
