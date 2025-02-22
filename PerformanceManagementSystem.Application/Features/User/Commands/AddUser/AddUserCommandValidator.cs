using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .MinimumLength(11).WithMessage("Phone must be exactly 11 characters.")
                .MaximumLength(11).WithMessage("Phone must be exactly 11 characters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(250).WithMessage("UserName must not exceed 250 characters.")
                .Must(x=> !unitOfWork.UserRepository.UsernameExists(x).Result)
                .WithMessage("Username Already Exists");

            RuleFor(x => x.DepartmentID)
                .Must(x => unitOfWork.DepartmentRepository.Exists(x).Result)
                .WithMessage("Department does not exist");
        }
    }
}
