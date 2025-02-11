using Mapster;
using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.AddUser;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDtoResponse>>>
    {
        public async Task<Result<IEnumerable<UserDtoResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Result<IEnumerable<UserDtoResponse>>.Ok(unitOfWork.UserRepository.GetAllAsync().Result.Adapt<IEnumerable<UserDtoResponse>>());
        }
    }
}
