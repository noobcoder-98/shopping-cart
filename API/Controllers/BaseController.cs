using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Core;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase {
    private IMediator mediator;
    protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    protected IActionResult HandleResult<T>(Result<T> result) {
        if (result == null) {
            return NotFound();
        } else if (result.IsSuccess && result.Value != null) {
            return Ok(result.Value);
        } else if (result.IsSuccess && result.Value == null) {
            return NotFound();
        } else {
            return BadRequest(result.Error);
        }
    }
}
