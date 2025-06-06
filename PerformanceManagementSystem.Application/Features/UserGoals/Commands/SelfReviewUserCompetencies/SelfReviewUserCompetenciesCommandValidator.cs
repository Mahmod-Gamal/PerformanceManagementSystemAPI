﻿using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserCompetencies;

public class UserCompetencySelfReviewValidator : AbstractValidator<UserCompetencySelfReview>
{
    public UserCompetencySelfReviewValidator()
    {
        // Rating must be between 1 and 4 (inclusive)
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 4)
            .WithMessage("Rating must be between 1 and 4.");

        // Comment is optional; if provided, it must not exceed 500 characters
        RuleFor(x => x.Comment)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Comment))
            .WithMessage("Comment must not exceed 500 characters.");
    }
}

public class SelfReviewUserCompetenciesCommandValidator : AbstractValidator<SelfReviewUserCompetenciesCommand>
{
    public SelfReviewUserCompetenciesCommandValidator()
    {
        // Apply the nested validator to each item in the UserCompetencies collection
        RuleForEach(x => x.userCompetencies)
            .SetValidator(new UserCompetencySelfReviewValidator());
    }
}
