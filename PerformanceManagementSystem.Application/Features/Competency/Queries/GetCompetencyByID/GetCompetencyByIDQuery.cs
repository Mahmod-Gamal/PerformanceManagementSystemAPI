using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID
{
    public class GetCompetencyByIDQuery : IRequest<Result<CompetencyDtoResponse>>
    {
        public int ID { get; set; }
    }
}
