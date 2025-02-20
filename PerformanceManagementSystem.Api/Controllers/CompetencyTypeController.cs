using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Application.Features.CompetencyType.Queries.GetAllCompetencyTypes;

namespace PerformanceManagementSystem.Api.Controllers
{
    // [Authorize]
    public class CompetencyTypeController(IMediator mediator) : BaseController
    {
        [HttpGet("GetAllCompetencyTypes")]
        public async Task<ActionResult<IEnumerable<CompetencyTypeDtoResponse>>> GetAllCompetencyTypes()
           => HandelResult(await mediator.Send(new GetAllCompetencyTypesQuery()));
    }
}
