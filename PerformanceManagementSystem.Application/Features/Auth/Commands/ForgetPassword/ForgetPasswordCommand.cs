using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommand : IRequest<Result<ForgetPasswordDtoResponse>>
    {
        public string Email { get; set; }
    }
}
