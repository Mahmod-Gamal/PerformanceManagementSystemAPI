using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning
{
    public class SelfReviewUserLearningCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserLearningReview> userLearnings;
    }
    public class UserLearningReview
    {
        public int ID { get; set; }
        public int Review { get; set; }
    }
}
