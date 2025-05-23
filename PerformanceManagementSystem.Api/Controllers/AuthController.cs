﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ForgetPassword;
using PerformanceManagementSystem.Application.Features.Auth.Commands.Login;
using PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword;
using Swashbuckle.AspNetCore.Annotations;


namespace PerformanceManagementSystem.Api.Controllers
{

    public class AuthController(IMediator mediator) : BaseController
    {

        [HttpPost("Login")]
        [SwaggerOperation(
        OperationId = nameof(Login))]
        public async Task<ActionResult<LoginDtoResponse>> Login(LoginCommand loginCommand)
            => HandelResult(await mediator.Send(loginCommand));

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ForgetPassword(ForgetPasswordCommand forgetPasswordCommand)
            => HandelResult(await mediator.Send(forgetPasswordCommand));

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ChangePassword(ChangePasswordCommand changePasswordCommand)
            => HandelResult(await mediator.Send(changePasswordCommand));

        [HttpPost("SetPassword")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SetPassword(SetPasswordCommand setPasswordCommand)
            => HandelResult(await mediator.Send(setPasswordCommand));

    }
}
