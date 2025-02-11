using Mapster;
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
        public async Task<Result<UserDtoResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = unitOfWork.UserRepository.GetByIdAsync(request.ID).Result;
            if (user == null)
                return Result<UserDtoResponse>.NotFound("User Not found");

            request.Adapt(user);

            return Result<UserDtoResponse>.Ok(user.Adapt<UserDtoResponse>());
        }
    }
}
