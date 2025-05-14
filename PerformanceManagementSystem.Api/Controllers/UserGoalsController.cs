using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserCompetencies;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SelfReviewUserObjectives;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserCompetencies;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.ManagerReviewUserObjectives;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserCompetencies;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserLearning;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetUserObjectives;
using Swashbuckle.AspNetCore.Annotations;
using PerformanceManagementSystem.Application.Features.UserGoals.Queries.GetUserGoals;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetObjectivesForUser;
using PerformanceManagementSystem.Application.Features.UserGoals.Commands.SetLearningForUser;

namespace PerformanceManagementSystem.Api.Controllers
{
    [Authorize]
    public class UserGoalsController(IMediator mediator) : BaseController
    {
        [HttpPut("SetObjectives")]
        public async Task<ActionResult<UserObjectivesDtoResponse>> SetObjectives(SetUserObjectivesCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SetLearnings")]
        public async Task<ActionResult<UserLearningDtoResponse>> SetLearnings(SetUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SetCompetencies")]
        public async Task<ActionResult<UserCompetenciesDtoResponse>> SetCompetencies(SetUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));


        [HttpPut("SetObjectivesForUser")]
        public async Task<ActionResult<UserObjectivesDtoResponse>> SetObjectivesForUser(SetObjectivesForUserCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SetLearningsForUser")]
        public async Task<ActionResult<UserLearningDtoResponse>> SetLearningsForUser(SetLearningForUserCommand command)
            => HandelResult(await mediator.Send(command));


        [HttpPut("SelfReviewObjectives")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewObjectives(SelfReviewUserObjectivesCommand command)
           => HandelResult(await mediator.Send(command));



        [HttpPut("SelfReviewLearnings")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewLearnings(SelfReviewUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("SelfReviewCompetencies")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> SelfReviewCompetencies(SelfReviewUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));


        [HttpPut("ManagerReviewObjectives")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewObjectives(ManagerReviewUserObjectivesCommand command)
           => HandelResult(await mediator.Send(command));



        [HttpPut("ManagerReviewLearnings")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewLearnings(ManagerReviewUserLearningCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpPut("ManagerReviewCompetencies")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ManagerReviewCompetencies(ManagerReviewUserCompetenciesCommand command)
                  => HandelResult(await mediator.Send(command));

        [HttpGet("GetUserGoals")]
        public async Task<ActionResult<UserGoalsDtoResponse>> GetUserGoals([FromQuery] GetUserGoalsQuery query)
              => HandelResult(await mediator.Send(query));

        [HttpGet("GetUserGoals/{Id}")]
        public async Task<ActionResult<UserGoalsDtoResponse>> GetUserGoalsByID(int Id)
              => HandelResult(await mediator.Send(new GetUserGoalsByIDQuery() { ID = Id }));


    }
}
