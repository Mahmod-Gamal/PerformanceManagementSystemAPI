using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommandValidator : AbstractValidator<AddDurationCommand>
    {
        public AddDurationCommandValidator()
        {
           
            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
