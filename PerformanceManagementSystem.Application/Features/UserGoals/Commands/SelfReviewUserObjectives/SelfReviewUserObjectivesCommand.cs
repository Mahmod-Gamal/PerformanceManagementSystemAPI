using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserObjectives
{
    public class SelfReviewUserObjectivesCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserObjectiveReview> userObjectives { get; set; }
    }
    public class UserObjectiveReview
    {
        public int ID { get; set; }
        public int Review { get; set; }
    }
}
