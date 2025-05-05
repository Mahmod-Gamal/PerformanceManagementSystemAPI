using FluentValidation;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserObjectives;

public class UserObjectiveSelfReviewValidator : AbstractValidator<UserObjectiveSelfReview>
{
    public UserObjectiveSelfReviewValidator()
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

        RuleFor(x => x.Achieved)
          .InclusiveBetween(0, 100)
          .WithMessage("Achieved must be between 0 and 100.");

        RuleFor(x => x.Weight)
            .InclusiveBetween(1, 100)
            .WithMessage("Weight must be between 1 and 100.");
    }
}

public class SelfReviewUserObjectivesCommandValidator : AbstractValidator<SelfReviewUserObjectivesCommand>
{
    public SelfReviewUserObjectivesCommandValidator()
    {
        // Apply the nested validator to each item in the UserObjectives collection
        RuleForEach(x => x.userObjectives)
            .SetValidator(new UserObjectiveSelfReviewValidator());

        // Total weight must equal exactly 100
        RuleFor(x => x.userObjectives.Sum(o => o.Weight))
            .Equal(100)
            .WithMessage("Total weight of all objectives must be exactly 100.");
    }
}
