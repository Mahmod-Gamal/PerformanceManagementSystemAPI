using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserCompetencyDto
    {
        public int ID { get; set; }
        public int CompetencyID { get; set; }
        public string CompetencyName { get; set; }
        public int? CurrentLevel { get; set; }
        public int? ExpectedLevel { get; set; }
        public int? Review { get; set; }
        public int? ManagerReview { get; set; }
    }
}
