using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommandValidator : AbstractValidator<AddCompetencyCommand>
    {
        public AddCompetencyCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Level)
            .Must(x=> x > 0 && x < 6).WithMessage("Level Must be in range 1-5");

            RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Definition is required.")
            .MaximumLength(50).WithMessage("Definition must not exceed 50 characters.");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

        }
    }
}
