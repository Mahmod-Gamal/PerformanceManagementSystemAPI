using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Features.Competency.Commands.DeleteCompetency
{
    public class DeleteCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCompetencyCommand, Result<AcknowledgmentDtoResponse>>
    {
        public async Task<Result<AcknowledgmentDtoResponse>> Handle(DeleteCompetencyCommand request, CancellationToken cancellationToken)
        {
            var Validator = new DeleteCompetencyCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<AcknowledgmentDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

            var acknowledgmentDtoResponse = new AcknowledgmentDtoResponse();
            return Result<AcknowledgmentDtoResponse>.Ok(acknowledgmentDtoResponse);
        }
    }
}
