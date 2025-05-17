using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserObjectives
{
    public class ManagerReviewUserObjectivesCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int UserID { get; set; }
        public List<UserObjectiveManagerReview> userObjectives { get; set; }
    }
    public class UserObjectiveManagerReview
    {
        public int ID { get; set; }
        public int ManagerRating { get; set; }
        public string ManagerComment { get; set; }

    }
}
