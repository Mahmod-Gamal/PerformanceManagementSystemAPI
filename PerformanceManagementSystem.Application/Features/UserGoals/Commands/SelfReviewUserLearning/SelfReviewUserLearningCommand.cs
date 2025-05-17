using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

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

    public class UserTrainingSelfReview
    {
        public int ID { get; set; }
        //public int Rating { get; set; }
        //public string Comment { get; set; }
        public DateTime? CertificateValidity { get; set; }
        public string? UploadedCertificate { get; set; }
        public bool? CourseTakenStatus { get; set; } // Indicates if the course was taken or not
    }
}
