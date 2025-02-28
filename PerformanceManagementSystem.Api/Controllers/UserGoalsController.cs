using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserTrainings;
using Swashbuckle.AspNetCore.Annotations;

namespace PerformanceManagementSystem.Api.Controllers
{
    [Authorize]
    public class UserGoalsController(IMediator mediator) : BaseController
    {
        [HttpPut("SetObjectives")]
        [SwaggerOperation(OperationId = nameof(SetObjectives))]
        public async Task<ActionResult<UserObjectivesDtoResponse>> SetObjectives(SetUserObjectivesCommand command)
            => HandelResult(await mediator.Send(command));
       
        [HttpPut("SetTrainings")]
        [SwaggerOperation(OperationId = nameof(SetTrainings))]
        public async Task<ActionResult<UserTrainingsDtoResponse>> SetTrainings(SetUserTrainingsCommand command)
            => HandelResult(await mediator.Send(command));
        
        [HttpPut("SetLearnings")]
        [SwaggerOperation(OperationId = nameof(SetLearnings))]
        public async Task<ActionResult<UserLearningDtoResponse>> SetLearnings(SetUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

    }
}
