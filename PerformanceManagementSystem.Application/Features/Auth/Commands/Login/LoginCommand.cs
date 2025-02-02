using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<LoginDtoResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
