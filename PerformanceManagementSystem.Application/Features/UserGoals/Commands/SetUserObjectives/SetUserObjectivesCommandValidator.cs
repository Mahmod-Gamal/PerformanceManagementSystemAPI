﻿using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives
{
    public class SetUserObjectivesCommandValidator : AbstractValidator<SetUserObjectivesCommand>
    {
        public SetUserObjectivesCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Year)
           .GreaterThan(0).WithMessage("Year is required");

            RuleForEach(x => x.UserObjectives).SetValidator(new ObjectiveValidator());

            // Total weight must equal exactly 100
            RuleFor(x => x.UserObjectives.Sum(o => o.Weight))
                .Equal(100)
                .WithMessage("Total weight of all objectives must be exactly 100.");
        }
    }

    public class ObjectiveValidator : AbstractValidator<Objective>
    {
        public ObjectiveValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.Measure)
                .NotEmpty().WithMessage("Measure is required")
                .MaximumLength(500).WithMessage("Measure cannot exceed 500 characters");

            RuleFor(x => x.Target)
                .NotEmpty().WithMessage("Target is required")
                .MaximumLength(500).WithMessage("Target cannot exceed 500 characters");

            RuleFor(x => x.DateFrom)
                .LessThan(x => x.DateTo).WithMessage("DateFrom must be before DateTo");

            RuleFor(x => x.Weight)
       .InclusiveBetween(1, 100)
       .WithMessage("Weight must be between 1 and 100.");
        }
    }
}
