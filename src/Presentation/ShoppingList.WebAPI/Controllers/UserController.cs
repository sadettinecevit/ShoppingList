using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;

namespace ShoppingList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetUserDto request)
        {
            HandlerResponse<List<GetByIdUserResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
