using MediatR;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result<ChangePasswordDtoResponse>>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
