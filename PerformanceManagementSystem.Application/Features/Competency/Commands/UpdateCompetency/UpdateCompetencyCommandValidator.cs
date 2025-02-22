using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommandValidator : AbstractValidator<UpdateCompetencyCommand>
    {
        public UpdateCompetencyCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => new { x.ID, x.Name })
                .Must(x => !unitOfWork.DurationRepository.NameExists(x.ID,x.Name).Result).WithMessage($"Duration Name Already Exists");

            RuleFor(x => x.Level)
                .Must(x => x > 0 && x < 6).WithMessage("Level Must be in range 1-5");

            RuleFor(x => x.Definition)
                .NotEmpty().WithMessage("Definition is required.")
                .MaximumLength(50).WithMessage("Definition must not exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

            RuleFor(x => x.StatusID)
                .Must(x => unitOfWork.StatusRepository.Exists(x).Result)
                .WithMessage("Status does not exist");
        }
    }
}
