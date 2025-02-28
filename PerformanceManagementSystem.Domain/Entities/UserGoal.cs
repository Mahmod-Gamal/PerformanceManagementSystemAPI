using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Domain.Entities
{
    public class UserGoal : BaseEntity
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public int StageID { get; set; }
        public ICollection<UserObjective> UserObjectives { get; set; }
        public ICollection<UserLearning> UserLearnings { get; set; }
        public ICollection<UserTraining> UserTrainings { get; set; }
    }
}
