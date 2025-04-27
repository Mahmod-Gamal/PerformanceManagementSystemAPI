using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserTrainings
{
    public class SelfReviewUserTrainingsCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserTrainingSelfReview> userTrainings { get; set; }
    }
    public class UserTrainingSelfReview
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
