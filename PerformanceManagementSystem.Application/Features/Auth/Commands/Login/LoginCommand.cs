using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<LoginDtoResponse>>
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
