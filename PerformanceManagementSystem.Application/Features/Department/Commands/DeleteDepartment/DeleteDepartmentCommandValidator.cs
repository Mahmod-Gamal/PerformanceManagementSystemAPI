using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {

            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
