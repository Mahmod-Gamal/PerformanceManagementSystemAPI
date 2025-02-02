using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
          
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Old password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password is required.");

            RuleFor(x => x.OldPassword)
                .NotEqual(x => x.NewPassword).WithMessage("Can't use Old Password as New Password.");

            RuleFor(x => x.NewPassword)
                .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
