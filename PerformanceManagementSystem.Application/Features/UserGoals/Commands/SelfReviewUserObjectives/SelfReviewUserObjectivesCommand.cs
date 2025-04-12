using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserObjectives
{
    public class SelfReviewUserObjectivesCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserObjectiveSelfReview> userObjectives { get; set; }
    }

    public class UserObjectiveSelfReview
    {
        public int ID { get; set; }
        public int Review { get; set; }
    }
}
