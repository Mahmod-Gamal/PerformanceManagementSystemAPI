using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.Department.Commands.AddDepartment;
using PerformanceManagementSystem.Application.Features.Department.Commands.DeleteDepartment;
using PerformanceManagementSystem.Application.Features.Department.Commands.UpdateDepartment;
using PerformanceManagementSystem.Application.Features.Department.Queries.GetAllDepartments;
using PerformanceManagementSystem.Application.Features.Department.Queries.GetDepartmentByID;

namespace PerformanceManagementSystem.Api.Controllers
{
    public class DepartmentController(IMediator mediator) : BaseController
    {

        
        [HttpPost("AddDepartment")]
        public async Task<ActionResult<DepartmentDtoResponse>> AddDepartment(AddDepartmentCommand command)
            => HandelResult(await mediator.Send(command));


        
        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult<DepartmentDtoResponse>> UpdateDepartment(UpdateDepartmentCommand command)
            => HandelResult(await mediator.Send(command));

        
        [HttpDelete("DeleteDepartment")]
        public async Task<ActionResult<AcknowledgmentDtoResponse>> DeleteDepartment(DeleteDepartmentCommand command)
            => HandelResult(await mediator.Send(command));

        
        [HttpGet("GetAllDepartments")]
        public async Task<ActionResult<IEnumerable<DepartmentDtoResponse>>> GetAllDepartments()
            => HandelResult(await mediator.Send(new GetAllDepartmentsQuery()));

        
        [HttpGet("GetDepartment/{ID}")]
        public async Task<ActionResult<DepartmentDtoResponse>> GetDepartment(int ID)
            => HandelResult(await mediator.Send(new GetDepartmentByIDQuery() { ID = ID }));


    }
}
