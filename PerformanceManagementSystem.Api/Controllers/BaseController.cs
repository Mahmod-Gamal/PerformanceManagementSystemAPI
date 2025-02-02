using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.Api.Utils;
using PerformanceManagementSystem.Application.Common.Results;

namespace PerformanceManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ResponseTemplate), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseTemplate), StatusCodes.Status401Unauthorized)]
    public class BaseController() : ControllerBase
    {
        public ActionResult HandelResult<T>(Result<T> result)
            => result.Status == Status.UnAuthorized ? Unauthorized()
            : result.Status == Status.BadRequest ? Problem(title: result.Error, statusCode: StatusCodes.Status400BadRequest)
            : result.Status == Status.NotFound ? NotFound()
            : result.Status == Status.OK ? Ok(result.Value)
            : result.Status == Status.ChangePassword ? StatusCode(406)
            : Problem(title: result.Error, statusCode: StatusCodes.Status500InternalServerError);
    }
}
