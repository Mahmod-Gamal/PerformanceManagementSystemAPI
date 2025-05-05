using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserGoalsDtoResponse
    {
        public UserGoalDto UserGoal { get; set; }
        public List<UserCompetencyDto> UserCoreCompetencies { get; set; }
        public List<UserCompetencyDto> UserFunctionalCompetencies { get; set; }
        public List<UserLearningDto> UserLearnings { get; set; }
        public List<UserObjectiveDto> UserObjectives { get; set; }
        public bool CanSetGoals { get; set; }
        public bool CanSelfReview { get; set; }
        public bool CanManagerReview { get; set; }
    }
}
