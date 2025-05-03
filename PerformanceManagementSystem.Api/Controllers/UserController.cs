using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.User.Commands.ActivateUser;
using PerformanceManagementSystem.Application.Features.User.Commands.AddUser;
using PerformanceManagementSystem.Application.Features.User.Commands.DeactivateUser;
using PerformanceManagementSystem.Application.Features.User.Commands.DeleteUser;
using PerformanceManagementSystem.Application.Features.User.Commands.UpdateUser;
using PerformanceManagementSystem.Application.Features.User.Queries.GetAllUsers;
using PerformanceManagementSystem.Application.Features.User.Queries.GetManagerEmployees;
using PerformanceManagementSystem.Application.Features.User.Queries.GetUserByID;
using Swashbuckle.AspNetCore.Annotations;

namespace PerformanceManagementSystem.Api.Controllers
{
    public class UserController(IMediator mediator) : BaseController
    {

        [HttpPost("AddUser")]
        [SwaggerOperation(OperationId = nameof(AddUser))]
        public async Task<ActionResult<UserDtoResponse>> AddUser(AddUserCommand command)
            => HandelResult(await mediator.Send(command));


        [HttpPut("UpdateUser")]
        [SwaggerOperation(OperationId = nameof(UpdateUser))]
        public async Task<ActionResult<UserDtoResponse>> UpdateUser(UpdateUserCommand command)
            => HandelResult(await mediator.Send(command)); 
        
        [HttpPut("ActivateUser")]
        [SwaggerOperation(OperationId = nameof(ActivateUser))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> ActivateUser(ActivateUserCommand command)
            => HandelResult(await mediator.Send(command)); 
        
        [HttpPut("DeactivateUser")]
        [SwaggerOperation(OperationId = nameof(DeactivateUser))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeactivateUser(DeactivateUserCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpDelete("DeleteUser")]
        [SwaggerOperation(OperationId = nameof(DeleteUser))]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteUser(DeleteUserCommand command)
            => HandelResult(await mediator.Send(command));

        [HttpGet("GetAllUsers")]
        [SwaggerOperation(OperationId = nameof(GetAllUsers))]
        public async Task<ActionResult<IEnumerable<UserDtoResponse>>> GetAllUsers()
            => HandelResult(await mediator.Send(new GetAllUsersQuery()));

        [HttpGet("GetUser/{ID}")]
        [SwaggerOperation(OperationId = nameof(GetUser))]
        public async Task<ActionResult<UserDtoResponse>> GetUser(int ID)
            => HandelResult(await mediator.Send(new GetUserByIDQuery() { ID = ID }));


        [HttpGet("GetManagedEmployees")]
        [SwaggerOperation(OperationId = nameof(GetManagedEmployees))]
        public async Task<ActionResult<IEnumerable<UserDtoResponse>>> GetManagedEmployees()
            => HandelResult(await mediator.Send(new GetManagerEmployeesQuery()));


    }
}
