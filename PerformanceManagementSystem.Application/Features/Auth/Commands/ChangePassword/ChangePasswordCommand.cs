using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
