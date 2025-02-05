using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations
{
    public class GetAllDurationsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllDurationsQuery, Result<IEnumerable<DurationDtoResponse>>>
    {
        public Task<Result<IEnumerable<DurationDtoResponse>>> Handle(GetAllDurationsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
