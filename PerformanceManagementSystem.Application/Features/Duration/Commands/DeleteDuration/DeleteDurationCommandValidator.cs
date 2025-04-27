using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration
{
    public class DeleteDurationCommandValidator : AbstractValidator<DeleteDurationCommand>
    {
        public DeleteDurationCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ID)
                .Must(x => !unitOfWork.DurationRepository.IsPrimary(x).Result).WithMessage("Can't Delete Primary Duration");

        }
    }
}
