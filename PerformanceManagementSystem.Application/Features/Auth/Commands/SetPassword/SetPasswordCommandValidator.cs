using FluentValidation;
using PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{
    public class SetPasswordCommandValidator : AbstractValidator<SetPasswordCommand>
    {
        public SetPasswordCommandValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.");


            RuleFor(x => x.NewPassword)
                .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
