using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommandValidator : AbstractValidator<AddCompetencyCommand>
    {
        public AddCompetencyCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
            .Must(x => !unitOfWork.CompetencyRepository.NameExists(x).Result).WithMessage($"Competency Name Already Exists");

            RuleFor(x => x.Definition)
            .NotEmpty().WithMessage("Definition is required.")
            .MaximumLength(250).WithMessage("Definition must not exceed 250 characters.");

            RuleFor(x => x.BasicLevelDescription)
       .NotEmpty().WithMessage("Basic Level Description is required.")
       .MaximumLength(1500).WithMessage("Basic Level Description must not exceed 1500 characters.");

            RuleFor(x => x.ProficientLevelDescription)
                .NotEmpty().WithMessage("Proficient Level Description is required.")
                .MaximumLength(1500).WithMessage("Proficient Level Description must not exceed 1500 characters.");

            RuleFor(x => x.AdvancedLevelDescription)
                .NotEmpty().WithMessage("Advanced Level Description is required.")
                .MaximumLength(1500).WithMessage("Advanced Level Description must not exceed 1500 characters.");

            RuleFor(x => x.ExpertLevelDescription)
                .NotEmpty().WithMessage("Expert Level Description is required.")
                .MaximumLength(1500).WithMessage("Expert Level Description must not exceed 1500 characters.");

        }
    }
}
