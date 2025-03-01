﻿using FluentValidation;
using PerformanceManagementSystem.Application.Interfaces.Persistence;

namespace PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration
{
    public class UpdateDurationCommandValidator : AbstractValidator<UpdateDurationCommand>
    {
        public UpdateDurationCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.ID)
                .GreaterThan(0).WithMessage("ID must be greater than 0.");

            RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Name is required.")
         .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x=> new {x.ID,x.Name})
           .Must(x => !unitOfWork.DurationRepository.NameExists(x.ID,x.Name).Result).WithMessage($"Duration Name Already Exists");

            RuleFor(x => x.End)
                .NotEmpty().WithMessage("End Date is required.")
                .GreaterThanOrEqualTo(x => x.Start).WithMessage("End Date must be after Start Date.");
        }
    }
}
