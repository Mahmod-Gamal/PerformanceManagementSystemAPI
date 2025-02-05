﻿using MediatR;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{
    public class SetPasswordCommand : IRequest<Result<AcknowledgmentDtoResponse>>
    {
        public string NewPassword { get; set; }
    }
}
