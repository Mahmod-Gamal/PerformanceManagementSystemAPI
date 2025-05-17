using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning;

public class ManagerLearningReviewValidator : AbstractValidator<UserLearningManagerReview>
{
    public ManagerLearningReviewValidator()
    {
        // Rating must be between 1 and 4 (inclusive)
        RuleFor(x => x.ManagerRating)
            .InclusiveBetween(1, 4)
            .WithMessage("Rating must be between 1 and 4.");

        // Comment is optional; if provided, it must not exceed 500 characters
        RuleFor(x => x.ManagerComment)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.ManagerComment))
            .WithMessage("Comment must not exceed 500 characters.");

        //RuleForEach(x => x.userTrainings)
        //   .SetValidator(new ManagerTrainingReviewValidator());
    }
}

public class ManagerReviewUserLearningCommandValidator : AbstractValidator<ManagerReviewUserLearningCommand>
{
    public ManagerReviewUserLearningCommandValidator()
    {
        // Apply the nested validator to each item in the userLearnings collection
        RuleForEach(x => x.userLearnings)
            .SetValidator(new ManagerLearningReviewValidator());
    }
}


public class ManagerTrainingReviewValidator : AbstractValidator<UserTrainingManagerReview>
{
    public ManagerTrainingReviewValidator()
    {
        /*
        // Rating must be between 1 and 4 (inclusive)
        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 4)
            .WithMessage("Rating must be between 1 and 4.");

        // Comment is optional; if provided, it must not exceed 500 characters
        RuleFor(x => x.Comment)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Comment))
            .WithMessage("Comment must not exceed 500 characters.");
        */
    }
}


