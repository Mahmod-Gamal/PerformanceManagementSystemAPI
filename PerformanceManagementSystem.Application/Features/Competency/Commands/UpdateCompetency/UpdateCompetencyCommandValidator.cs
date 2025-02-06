using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency
{
    public class UpdateCompetencyCommandValidator : AbstractValidator<UpdateCompetencyCommand>
    {
        public UpdateCompetencyCommandValidator()
        {

            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
