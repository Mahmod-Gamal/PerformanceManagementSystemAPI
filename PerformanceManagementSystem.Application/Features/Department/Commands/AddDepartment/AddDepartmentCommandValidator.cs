using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment
{
    public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
            .Must(x => !unitOfWork.DepartmentRepository.NameExists(x).Result).WithMessage($"Department Name Already Exists");

            /*
            RuleFor(x => x.CompetincyIDs)
                .Must(x => x == null ||  x.All(c => unitOfWork.CompetencyRepository.Exists(c).Result))
                .WithMessage("One or more Competencies IDs are not found");
            */
        }
    }
}
