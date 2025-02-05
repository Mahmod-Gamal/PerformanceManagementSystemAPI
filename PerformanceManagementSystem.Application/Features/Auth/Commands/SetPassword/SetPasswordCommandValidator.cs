using FluentValidation;

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
