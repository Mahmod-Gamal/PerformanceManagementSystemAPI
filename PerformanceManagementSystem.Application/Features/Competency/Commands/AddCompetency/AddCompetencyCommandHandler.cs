using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using PerformanceManagementSystem.Application.Common.Results;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using System.Security.Claims;


namespace PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency
{
    public class AddCompetencyCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCompetencyCommand, Result<CompetencyDtoResponse>>
    {
        public async Task<Result<CompetencyDtoResponse>> Handle(AddCompetencyCommand request, CancellationToken cancellationToken)
        {
            var Validator = new AddCompetencyCommandValidator();
            var validationResult = Validator.Validate(request);
            if (!validationResult.IsValid)
                return Result<CompetencyDtoResponse>.BadRequest(validationResult.Errors.First().ErrorMessage);

         
            var competency = request.Adapt<Domain.Entities.Competency>();

            await unitOfWork.CompetencyRepository.AddAsync(competency);
            unitOfWork.CommitAsync();

            return Result<DurationDtoResponse>.Ok(competency.Adapt<CompetencyDtoResponse>());
        }
    }
}
