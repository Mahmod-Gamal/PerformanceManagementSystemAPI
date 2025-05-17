using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetObjectivesForUser
{
    public class SetObjectivesForUserCommand : ICommand<Result<UserObjectivesDtoResponse>>
    {
        public int Year { get; set; }
        public int UserID { get; set; }
        public List<UserObjective> UserObjectives { get; set; }
    }
    public class UserObjective
    {
        public string Description { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }
        public int Weight { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
