using FluentValidation;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator()
        {
           
            //RuleFor(x => x.NewPassword)
            //    .MinimumLength(8).WithMessage("New password is too short.");
        }
    }
}
