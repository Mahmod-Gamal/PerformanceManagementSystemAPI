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

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetDepartmentEmployees
{
    public class GetDepartmentEmployeesQueryHandler(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor) : IRequestHandler<GetDepartmentEmployeesQuery, Result<IEnumerable<UserDtoResponse>>>
    {
        public async Task<Result<IEnumerable<UserDtoResponse>>> Handle(GetDepartmentEmployeesQuery request, CancellationToken cancellationToken)
        {
            var userId = contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await unitOfWork.UserRepository.GetByIdAsync(int.Parse(userId));
            if (user is null)
                return Result<IEnumerable<UserDtoResponse>>.UnAuthorized("User not found");
            if (user.UserTypeId > 2)
                return Result<IEnumerable<UserDtoResponse>>.UnAuthorized("User is not an Admin");

            return Result<IEnumerable<UserDtoResponse>>.Ok(unitOfWork.UserRepository.GetUsersByDepartmentID(request.ID).Result.Adapt<IEnumerable<UserDtoResponse>>());
        }
    }
}
