using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserGoals
{
 
    public class GetUserGoalsByIDQuery : IRequest<Result<UserGoalsDtoResponse>>
    {
        public int ID { get; set; }
    }
}
