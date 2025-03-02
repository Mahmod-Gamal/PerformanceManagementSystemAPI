using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies
{
    public class SetUserCompetenciesCommand : ICommand<Result<UserCompetenciesDtoResponse>>
    {
        public int Year { get; set; }
        public List<Competencies> Competenciess { get; set; }
    }
    public class Competencies
    {
        public int CompetencyID { get; set; }
        public int PerviousLevel { get; set; }
        public int CurrentLevel { get; set; }
    }

}
