using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {

            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
