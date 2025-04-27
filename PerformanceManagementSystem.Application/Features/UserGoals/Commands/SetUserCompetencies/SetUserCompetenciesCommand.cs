using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies
{
    public class SetUserCompetenciesCommand : ICommand<Result<UserCompetenciesDtoResponse>>
    {
        public int Year { get; set; }
        public List<Competencies> CoreCompetenciess { get; set; }
        public List<Competencies> FunctionalCompetenciess { get; set; }

    }
    public class Competencies
    {
        public int CompetencyID { get; set; }
        public int CurrentLevel { get; set; }
        public int ExpectedLevel { get; set; }
    }

}
