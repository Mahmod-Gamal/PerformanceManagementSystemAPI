using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning
{
    public class ManagerReviewUserLearningCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int UserID { get; set; }
        public List<UserLearningReview> userLearnings;
    }
    public class UserLearningReview
    {
        public int ID { get; set; }
        public int Review { get; set; }
    }
}
