using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserObjectives;

public class ManagerObjectiveReviewValidator : AbstractValidator<UserObjectiveManagerReview>
{
    public ManagerObjectiveReviewValidator()
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

public class ManagerReviewUserObjectivesCommandValidator : AbstractValidator<ManagerReviewUserObjectivesCommand>
{
    public ManagerReviewUserObjectivesCommandValidator()
    {
        // Apply the nested validator to each item in the userObjectives collection
        RuleForEach(x => x.userObjectives)
            .SetValidator(new ManagerObjectiveReviewValidator());
    }
}
