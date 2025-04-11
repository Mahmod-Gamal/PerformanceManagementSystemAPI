using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Competency.Commands.AddCompetency;
using PerformanceManagementSystem.Application.Features.Competency.Commands.DeleteCompetency;
using PerformanceManagementSystem.Application.Features.Competency.Commands.UpdateCompetency;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetAllCompetencies;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetBehavioralCompetencies;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetenciesByDepartmentID;
using PerformanceManagementSystem.Application.Features.Competency.Queries.GetCompetencyByID;

namespace PerformanceManagementSystem.Api.Controllers
{
    // [Authorize]
    public class CompetencyController(IMediator mediator) : BaseController
    {

        [HttpPost("AddCompetency")]
        public async Task<ActionResult<CompetencyDtoResponse>> AddCompetency(AddCompetencyCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("UpdateCompetency")]
        public async Task<ActionResult<CompetencyDtoResponse>> UpdateCompetency(UpdateCompetencyCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpDelete("DeleteCompetency")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteCompetency(DeleteCompetencyCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpGet("GetAllCompetencies")]
        public async Task<ActionResult<IEnumerable<CompetencyDtoResponse>>> GetAllCompetencies()
            => HandelResult(await mediator.Send(new GetAllCompetenciesQuery()));

        [HttpGet("GetCompetency/{ID}")]
        public async Task<ActionResult<CompetencyDtoResponse>> GetCompetency(int ID)
            => HandelResult(await mediator.Send(new GetCompetencyByIDQuery() { ID = ID }));

        [HttpGet("GetBehavioralCompetencies")]
        public async Task<ActionResult<CompetencyDtoResponse>> GetBehavioralCompetencies()
            => HandelResult(await mediator.Send(new GetBehavioralCompetenciesQuery()));

        [HttpGet("GetCompetenciesByDepartment/{ID}")]
        public async Task<ActionResult<CompetencyDtoResponse>> GetCompetenciesByDepartment(int ID)
            => HandelResult(await mediator.Send(new GetCompetenciesByDepartmentIDQuery() { DepartmentID = ID }));


    }
}
