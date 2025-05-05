using PerformanceManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer
{
    public interface IRichDataInitializer : IDataInitializer
    {
        List<Competency> CompetenciesSeed();
        List<Department> DepartmentsSeed();
        List<UserGoal> GoalsSeed();
        List<UserCompetency> UserCompetenciesSeed();
        List<UserLearning> UserLearningSeed();
        List<UserObjective> UserObjectivesSeed();
        List<UserTraining> UserTrainingSeed();
    }
}
