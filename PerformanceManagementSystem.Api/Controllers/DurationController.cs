using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PerformanceManagementSystem.Api.Controllers;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration;
using PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration;
using PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations;
using PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID;

namespace PerformanceManagementSystem.Api.Controllers
{
    public class DurationController(IMediator mediator) : BaseController
    {

        [Authorize]
        [HttpPost("AddDuration")]
        public async Task<ActionResult<DurationDtoResponse>> AddDuration(AddDurationCommand command)
            => HandelResult(await mediator.Send(command));


        [Authorize]
        [HttpPut("UpdateDuration")]
        public async Task<ActionResult<DurationDtoResponse>> UpdateDuration(UpdateDurationCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpDelete("DeleteDuration")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteDuration(DeleteDurationCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpGet("GetAllDurations")]
        public async Task<ActionResult<IEnumerable<DurationDtoResponse>>> GetAllDurations()
            => HandelResult(await mediator.Send(new GetAllDurationsQuery()));

        [Authorize]
        [HttpGet("GetDuration/{ID}")]
        public async Task<ActionResult<DurationDtoResponse>> GetDuration(int ID)
            => HandelResult(await mediator.Send(new GetDurationByIDQuery() {ID = ID}));


    }
}