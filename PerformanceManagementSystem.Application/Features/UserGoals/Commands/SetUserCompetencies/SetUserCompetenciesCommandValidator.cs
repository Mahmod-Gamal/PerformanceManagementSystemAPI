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

            RuleForEach(x => x.Competenciess).SetValidator(new CompetenciesValidator(unitOfWork));
        }
    }

    public class CompetenciesValidator : AbstractValidator<Competencies>
    {
        public CompetenciesValidator(IUnitOfWork unitOfWork)
        {
            //RuleFor(x => x.CurrentLevel)
            //    .InclusiveBetween(1, 5).WithMessage("CurrentLevel is not Valis [1-5]");
            //RuleFor(x => x.PerviousLevel)
            //    .InclusiveBetween(1, 5).WithMessage("PerviousLevel is not Valis [1-5]");
            RuleFor(x => x.CompetencyID).Must(x => unitOfWork.CompetencyRepository.Exists(x).Result)
                .WithMessage("CompetencyID not Found");
        }
    }
}
