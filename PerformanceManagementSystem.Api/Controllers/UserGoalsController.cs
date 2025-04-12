using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserCompetencies;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserObjectives;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserTrainings;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserCompetencies;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserObjectives;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserTrainings;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies;
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

        [HttpPut("SetCompetencies")]
        [SwaggerOperation(OperationId = nameof(SetCompetencies))]
        public async Task<ActionResult<UserCompetenciesDtoResponse>> SetCompetencies(SetUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));

        [HttpPut("SelfReviewObjectives")]
        [SwaggerOperation(OperationId = nameof(SelfReviewObjectives))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewObjectives(SelfReviewUserObjectivesCommand command)
           => HandelResult(await mediator.Send(command));

        [HttpPut("SelfReviewTrainings")]
        [SwaggerOperation(OperationId = nameof(SelfReviewTrainings))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewTrainings(SelfReviewUserTrainingsCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SelfReviewLearnings")]
        [SwaggerOperation(OperationId = nameof(SelfReviewLearnings))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewLearnings(SelfReviewUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SelfReviewCompetencies")]
        [SwaggerOperation(OperationId = nameof(SelfReviewCompetencies))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewCompetencies(SelfReviewUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));


        [HttpPut("ManagerReviewObjectives")]
        [SwaggerOperation(OperationId = nameof(ManagerReviewObjectives))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewObjectives(ManagerReviewUserObjectivesCommand command)
           => HandelResult(await mediator.Send(command));

        [HttpPut("ManagerReviewTrainings")]
        [SwaggerOperation(OperationId = nameof(ManagerReviewTrainings))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewTrainings(ManagerReviewUserTrainingsCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("ManagerReviewLearnings")]
        [SwaggerOperation(OperationId = nameof(ManagerReviewLearnings))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewLearnings(ManagerReviewUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("ManagerReviewCompetencies")]
        [SwaggerOperation(OperationId = nameof(ManagerReviewCompetencies))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewCompetencies(ManagerReviewUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));


    }
}
