using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.DeleteCompetency
{
    public class DeleteCompetencyCommandValidator : AbstractValidator<DeleteCompetencyCommand>
    {
        public DeleteCompetencyCommandValidator()
        {

            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
