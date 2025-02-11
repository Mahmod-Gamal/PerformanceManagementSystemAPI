using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID
{
    public class GetUserByIDQuery : IRequest<Result<UserDtoResponse>>
    {
        public int ID { get; set; }
    }
}
