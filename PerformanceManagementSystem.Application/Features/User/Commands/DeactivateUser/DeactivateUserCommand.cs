﻿using PerformanceManagementSystem.Application.Common.Interfaces;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.User.Commands.DeactivateUser
{
    public class DeactivateUserCommand : ICommand<Result<AcknowledgmentDtoResponse>>
    {
        public int ID { get; set; }
    }
}
