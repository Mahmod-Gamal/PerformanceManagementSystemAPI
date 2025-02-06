using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommandValidator : AbstractValidator<AddCompetencyCommand>
    {
        public AddCompetencyCommandValidator()
        {
           
            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
