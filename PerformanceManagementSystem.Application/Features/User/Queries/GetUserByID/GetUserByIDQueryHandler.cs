using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID
{
    public class GetUserByIDQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIDQuery, Result<UserDtoResponse>>
    {
        public Task<Result<UserDtoResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
