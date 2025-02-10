using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.SetPassword
{
    public class SetPasswordCommandValidator : AbstractValidator<SetPasswordCommand>
    {
        public SetPasswordCommandValidator()
        {

            RuleFor(x => x.OTT)
                .NotEmpty().WithMessage("New password is required.");

            //RuleFor(x => x.OTT)
            //    .Must(x=> x.Split(':').Length == 2).WithMessage("Invalid OTT");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.");

            RuleFor(x => x.NewPassword)
                .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
