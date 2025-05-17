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

   
    }
}

public class SelfReviewUserObjectivesCommandValidator : AbstractValidator<SelfReviewUserObjectivesCommand>
{
    public SelfReviewUserObjectivesCommandValidator()
    {
        // Apply the nested validator to each item in the UserObjectives collection
        RuleForEach(x => x.userObjectives)
            .SetValidator(new UserObjectiveSelfReviewValidator());


    }
}
