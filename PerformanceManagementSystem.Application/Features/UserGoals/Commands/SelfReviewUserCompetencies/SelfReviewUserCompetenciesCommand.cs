using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserCompetencies
{
    public class SelfReviewUserCompetenciesCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public List<UserCompetencySelfReview> userCompetencies { get; set; }
    }
    public class UserCompetencySelfReview
    {
        public int ID { get; set; }
        public int Review {  get; set; }
    }
}
