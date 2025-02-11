using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
