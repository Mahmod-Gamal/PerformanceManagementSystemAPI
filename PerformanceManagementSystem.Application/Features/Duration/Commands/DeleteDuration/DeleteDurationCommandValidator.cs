using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration
{
    public class DeleteDurationCommandValidator : AbstractValidator<DeleteDurationCommand>
    {
        public DeleteDurationCommandValidator()
        {
            RuleFor(x => x.ID)
           .GreaterThan(0).WithMessage("ID must be greater than 0.");
        }
    }
}
