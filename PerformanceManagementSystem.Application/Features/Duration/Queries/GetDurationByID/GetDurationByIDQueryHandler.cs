using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID
{
    public class GetDurationByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDurationByIDQuery, Result<DurationDtoResponse>>
    {
        public Task<Result<DurationDtoResponse>> Handle(GetDurationByIDQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
