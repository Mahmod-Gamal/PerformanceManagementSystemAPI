using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration
{
    public class AddDurationCommandValidator : AbstractValidator<AddDurationCommand>
    {
        public AddDurationCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
           .Must(x => !unitOfWork.DurationRepository.NameExists(x).Result).WithMessage($"Duration Already Exists");


            RuleFor(x => x.End)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(x => x.Start).WithMessage("End Date must be after Start Date.");
        }

    }
}
