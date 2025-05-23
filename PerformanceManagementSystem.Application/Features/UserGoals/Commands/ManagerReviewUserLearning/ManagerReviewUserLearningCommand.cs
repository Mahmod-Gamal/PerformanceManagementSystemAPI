using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning
{
    public class ManagerReviewUserLearningCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int UserID { get; set; }
        public List<UserLearningManagerReview> userLearnings { get; set; }
    }
    public class UserLearningManagerReview
    {
        public int ID { get; set; }
        public int ManagerRating { get; set; }
        public string ManagerComment { get; set; }
        //public List<UserTrainingManagerReview> userTrainings { get; set; }

    }

    public class UserTrainingManagerReview
    {
        public int ID { get; set; }
     //   public int Rating { get; set; }
       // public string Comment { get; set; }

    }
}
