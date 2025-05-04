using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserTrainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning
{
    public class SelfReviewUserLearningCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserLearningSelfReview> userLearnings { get; set; }
    }
    public class UserLearningSelfReview
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public List<UserTrainingSelfReview> userTrainings { get; set; }

    }
}
