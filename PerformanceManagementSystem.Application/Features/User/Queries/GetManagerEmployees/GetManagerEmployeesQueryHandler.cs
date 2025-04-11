using MediatR;
using Mapster;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetManagerEmployees
{
    public class GetManagerEmployeesQueryHandler(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor) : IRequestHandler<GetManagerEmployeesQuery, Result<IEnumerable<UserDtoResponse>>>
    {
        public async Task<Result<IEnumerable<UserDtoResponse>>> Handle(GetManagerEmployeesQuery request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<IEnumerable<UserDtoResponse>>.UnAuthorized("User not found");
            if (user.UserTypeId != 3)
                return Result<IEnumerable<UserDtoResponse>>.UnAuthorized("User is not a Manager");

            return Result<IEnumerable<UserDtoResponse>>.Ok(unitOfWork.UserRepository.GetManagedUsersByManagerID(user.ID).Result.Adapt<IEnumerable<UserDtoResponse>>());
        }
    }
}
