using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning;

public class UserLearningSelfReviewValidator : AbstractValidator<UserLearningSelfReview>
{
    public UserLearningSelfReviewValidator()
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

public class SelfReviewUserLearningCommandValidator : AbstractValidator<SelfReviewUserLearningCommand>
{
    public SelfReviewUserLearningCommandValidator()
    {
        // Apply the nested validator to each item in the UserLearnings collection
        RuleForEach(x => x.userLearnings)
            .SetValidator(new UserLearningSelfReviewValidator());
    }
}
