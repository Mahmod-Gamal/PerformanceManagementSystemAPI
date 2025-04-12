using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.DTOs
{
    public class UserGoalDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Year { get; set; }
        public int StageID { get; set; }
    }
}
