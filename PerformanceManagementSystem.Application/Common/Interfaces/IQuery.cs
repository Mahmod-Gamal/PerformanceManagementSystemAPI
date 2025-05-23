﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Common.Interfaces
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }

}
