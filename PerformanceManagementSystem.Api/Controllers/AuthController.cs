using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.Login;
using PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword;
 

namespace PerformanceManagementSystem.Api.Controllers
{

    public class AuthController(IMediator mediator) : BaseController
    {

        [HttpPost("Login")]
        public async Task<ActionResult<LoginDtoResponse>> Login(LoginCommand loginCommand)
            => HandelResult(await mediator.Send(loginCommand));

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult<ForgetPasswordDtoResponse>> ForgetPassword(ForgetPasswordCommand forgetPasswordCommand)
            => HandelResult(await mediator.Send(forgetPasswordCommand));

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult<ChangePasswordDtoResponse>> ChangePassword(ChangePasswordCommand changePasswordCommand)
            => HandelResult(await mediator.Send(changePasswordCommand));

        [Authorize]
        [HttpPost("SetPassword")]
        public async Task<ActionResult<SetPasswordDtoResponse>> SetPassword(SetPasswordCommand setPasswordCommand)
            => HandelResult(await mediator.Send(setPasswordCommand));

    }
}
