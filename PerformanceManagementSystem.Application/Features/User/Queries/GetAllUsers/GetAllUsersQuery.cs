using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Result<IEnumerable<UserDtoResponse>>>
    {
    }
}
