using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.AddUser;
using PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser;
using PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers;
using PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID;
using Swashbuckle.AspNetCore.Annotations;

namespace PerformanceManagementSystem.Api.Controllers
{
    public class UserController(IMediator mediator) : BaseController
    {

        [Authorize]
        [HttpPost("AddUser")]
        [SwaggerOperation(OperationId = nameof(AddUser))]
        public async Task<ActionResult<UserDtoResponse>> AddUser(AddUserCommand command)
            => HandelResult(await mediator.Send(command));


        [Authorize]
        [HttpPut("UpdateUser")]
        [SwaggerOperation(OperationId = nameof(UpdateUser))]
        public async Task<ActionResult<UserDtoResponse>> UpdateUser(UpdateUserCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpDelete("DeleteUser")]
        [SwaggerOperation(OperationId = nameof(DeleteUser))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteUser(AddUserCommand command)
            => HandelResult(await mediator.Send(command));

        [Authorize]
        [HttpGet("GetAllUsers")]
        [SwaggerOperation(OperationId = nameof(GetAllUsers))]
        public async Task<ActionResult<IEnumerable<UserDtoResponse>>> GetAllUsers()
            => HandelResult(await mediator.Send(new GetAllUsersQuery()));

        [Authorize]
        [HttpGet("GetUser/{ID}")]
        [SwaggerOperation(OperationId = nameof(GetUser))]
        public async Task<ActionResult<UserDtoResponse>> GetUser(int ID)
            => HandelResult(await mediator.Send(new GetUserByIDQuery() { ID = ID }));


    }
}
