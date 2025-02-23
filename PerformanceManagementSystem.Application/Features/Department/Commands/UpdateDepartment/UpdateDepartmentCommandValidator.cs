using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => new { x.ID, x.Name })
                .Must(x => !unitOfWork.DepartmentRepository.NameExists(x.ID, x.Name).Result)
                .WithMessage("Department Name Already Exists");

            RuleFor(x => x.StatusID)
                .Must(x => unitOfWork.StatusRepository.Exists(x).Result)
                .WithMessage("Status does not exist");

            /*
            RuleFor(x => x.CompetincyIDs)
                .Must(x => x.All(c => unitOfWork.CompetencyRepository.Exists(c).Result))
                .WithMessage("One or more Competencies IDs are not found");
            */
        }
    }
}
