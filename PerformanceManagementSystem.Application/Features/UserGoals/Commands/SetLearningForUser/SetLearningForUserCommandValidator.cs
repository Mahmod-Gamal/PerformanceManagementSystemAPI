using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetLearningForUser
{
    public class SetLearningForUserCommandValidator : AbstractValidator<SetLearningForUserCommand>
    {
        public SetLearningForUserCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Year)
           .GreaterThan(0).WithMessage("Year is required");

            RuleForEach(x => x.Learnings).SetValidator(new LearningValidator());


        }
    }

    public class LearningValidator : AbstractValidator<Learning>
    {
        public LearningValidator()
        {
            RuleFor(x => x.ImprovementArea)
                .NotEmpty().WithMessage("ImprovementArea is required")
                .MaximumLength(500).WithMessage("ImprovementArea cannot exceed 500 characters");

            RuleFor(x => x.Action)
                .NotEmpty().WithMessage("Action is required")
                .MaximumLength(500).WithMessage("Action cannot exceed 500 characters");

            RuleForEach(x => x.UserTrainings).SetValidator(new TrainingsValidator());

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