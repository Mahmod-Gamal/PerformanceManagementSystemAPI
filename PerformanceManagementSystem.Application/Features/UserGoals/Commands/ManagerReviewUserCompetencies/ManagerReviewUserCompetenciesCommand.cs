using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserCompetencies
{
    public class ManagerReviewUserCompetenciesCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int UserID { get; set; }
        public List<UserCompetencyManagerReview> userCompetencies { get; set; }
    }
    public class UserCompetencyManagerReview
    {
        public int ID { get; set; }
        public int Review {  get; set; }
    }
}
