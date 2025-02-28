using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserTrainings
{
    public class SetUserTrainingsCommandValidator : AbstractValidator<SetUserTrainingsCommand>
    {
        public SetUserTrainingsCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Year)
           .GreaterThan(0).WithMessage("Year is required");

            RuleForEach(x => x.Trainingss).SetValidator(new TrainingsValidator());
        }
    }

    public class TrainingsValidator : AbstractValidator<Trainings>
    {
        public TrainingsValidator()
        {
            RuleFor(x => x.TrainingCourse)
                .NotEmpty().WithMessage("ImprovementArea is required")
                .MaximumLength(500).WithMessage("ImprovementArea cannot exceed 500 characters");

            RuleFor(x => x.InstituteOfSource)
                .NotEmpty().WithMessage("Action is required")
                .MaximumLength(500).WithMessage("Action cannot exceed 500 characters");

            RuleFor(x => x.DateFrom)
                .LessThan(x => x.DateTo).WithMessage("DateFrom must be before DateTo");
        }
    }
}
