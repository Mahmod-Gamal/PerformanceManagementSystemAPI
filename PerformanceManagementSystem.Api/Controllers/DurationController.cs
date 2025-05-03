using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using PerformanceManagementSystem.Application.Features.Duration.Commands.DeleteDuration;
using PerformanceManagementSystem.Application.Features.Duration.Commands.DurationNotification;
using PerformanceManagementSystem.Application.Features.Duration.Commands.UpdateDuration;
using PerformanceManagementSystem.Application.Features.Duration.Queries.GetAllDurations;
using PerformanceManagementSystem.Application.Features.Duration.Queries.GetDurationByID;

namespace PerformanceManagementSystem.Api.Controllers
{
   // [Authorize]
    public class DurationController(IMediator mediator) : BaseController
    {

        [HttpPost("AddDuration")]
        public async Task<ActionResult<DurationDtoResponse>> AddDuration(AddDurationCommand command)
            => HandelResult(await mediator.Send(command));


        [HttpPut("UpdateDuration")]
        public async Task<ActionResult<DurationDtoResponse>> UpdateDuration(UpdateDurationCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpDelete("DeleteDuration")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteDuration(DeleteDurationCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpGet("GetAllDurations")]
        public async Task<ActionResult<IEnumerable<DurationDtoResponse>>> GetAllDurations()
            => HandelResult(await mediator.Send(new GetAllDurationsQuery()));

        [HttpGet("GetDuration/{ID}")]
        public async Task<ActionResult<DurationDtoResponse>> GetDuration(int ID)
            => HandelResult(await mediator.Send(new GetDurationByIDQuery() { ID = ID }));


        [HttpPut("NotifyDuration/{ID}")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> NotifyDuration(int ID)
            => HandelResult(await mediator.Send(new DurationNotificationCommand() { ID = ID}));

    }
}