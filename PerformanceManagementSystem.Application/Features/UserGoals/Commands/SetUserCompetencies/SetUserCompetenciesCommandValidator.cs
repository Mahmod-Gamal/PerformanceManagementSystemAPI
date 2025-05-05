using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies
{
    public class SetUserCompetenciesCommandValidator : AbstractValidator<SetUserCompetenciesCommand>
    {
        public SetUserCompetenciesCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Year)
                .GreaterThan(0).WithMessage("Year is required");

            // Validate that CoreCompetenciess has exactly 4 elements
            RuleFor(x => x.CoreCompetenciess)
                .Must(x => x != null && x.Count == 4)
                .WithMessage("Core Competenciess must contain exactly 4 competencies.");

            // Validate that FunctionalCompetenciess has exactly 4 elements
            RuleFor(x => x.FunctionalCompetenciess)
                .Must(x => x != null && x.Count == 4)
                .WithMessage("Functional Competenciess must contain exactly 4 competencies.");

            RuleForEach(x => x.CoreCompetenciess).SetValidator(new CompetenciesValidator(unitOfWork));
            RuleForEach(x => x.FunctionalCompetenciess).SetValidator(new CompetenciesValidator(unitOfWork));
        }
    }

    public class CompetenciesValidator : AbstractValidator<Competencies>
    {
        public CompetenciesValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.CompetencyID)
                .Must(x => unitOfWork.CompetencyRepository.Exists(x).Result)
                .WithMessage("CompetencyID not Found");

            // Optional: Uncomment if you want to validate CurrentLevel and ExpectedLevel between 1 and 5
            // RuleFor(x => x.CurrentLevel)
            //    .InclusiveBetween(1, 5).WithMessage("CurrentLevel is not Valid [1-5]");

            // RuleFor(x => x.ExpectedLevel)
            //    .InclusiveBetween(1, 5).WithMessage("ExpectedLevel is not Valid [1-5]");
        }
    }
}
