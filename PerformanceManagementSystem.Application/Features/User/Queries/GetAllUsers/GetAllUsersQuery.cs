using MediatR;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<Result<IEnumerable<UserDtoResponse>>>
    {
    }
}
