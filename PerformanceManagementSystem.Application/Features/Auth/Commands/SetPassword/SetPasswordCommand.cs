using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public string OTT { get; set; }
        public string NewPassword { get; set; }
    }
}
