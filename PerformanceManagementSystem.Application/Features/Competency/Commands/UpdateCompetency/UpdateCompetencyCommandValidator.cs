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
                .Must(x => !unitOfWork.DurationRepository.NameExists(x.ID, x.Name).Result).WithMessage($"Duration Name Already Exists");


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




            RuleFor(x => x.StatusID)
                .Must(x => unitOfWork.StatusRepository.Exists(x).Result)
                .WithMessage("Status does not exist");
        }
    }
}
