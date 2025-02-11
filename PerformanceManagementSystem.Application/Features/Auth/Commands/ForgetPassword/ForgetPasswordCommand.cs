using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public string Email { get; set; }
    }
}
