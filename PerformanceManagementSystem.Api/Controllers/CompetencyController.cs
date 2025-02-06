using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency;
using PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID;

namespace PerformanceManagementSystem.Api.Controllers
{
    public class CompetencyController(IMediator mediator) : BaseController
    {

        [Authorize]
        [HttpPost("AddCompetency")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> AddCompetency(AddCompetencyCommand command)
            => HandelResult(await mediator.Send(command));


        [Authorize]
        [HttpPut("UpdateCompetency")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> UpdateCompetency(UpdateCompetencyCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpDelete("DeleteCompetency")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteCompetency(AddCompetencyCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpGet("GetAllCompetencies")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> GetAllCompetencies()
            => HandelResult(await mediator.Send(new GetAllCompetenciesQuery()));

        [Authorize]
        [HttpGet("GetCompetency/{ID}")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> GetCompetency(int ID)
            => HandelResult(await mediator.Send(new GetCompetencyByIDQuery() { ID = ID }));


    }
}
