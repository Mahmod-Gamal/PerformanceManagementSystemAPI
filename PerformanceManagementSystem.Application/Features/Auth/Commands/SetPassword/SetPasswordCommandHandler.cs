using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{


    public class SetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager) : IRequestHandler<SetPasswordCommand, Result<SetPasswordDtoResponse>>
    {

        public Task<Result<SetPasswordDtoResponse>> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
