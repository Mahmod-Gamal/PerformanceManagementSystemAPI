using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommandValidator : AbstractValidator<AddDurationCommand>
    {
        public AddDurationCommandValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            //RuleFor(x => x.Start)
            // .NotEmpty().WithMessage("Start Date is required.")
            //.Must(start => start > DateOnly.FromDateTime(DateTime.Now))
            // .WithMessage("Start Date must be after today.");

            RuleFor(x => x.End)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(x => x.Start).WithMessage("End Date must be after Start Date.");
        }

    }
}
