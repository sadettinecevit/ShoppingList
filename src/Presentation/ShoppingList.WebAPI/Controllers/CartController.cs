using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]
    public class CartController : ControllerBase
    {
        IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetCartDto request)
        {
            HandlerResponse<List<GetByIdCartResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCartDto request)
        {
            HandlerResponse<GetByIdCartResponseDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateCartDto request)
        {
            IActionResult result;
            HandlerResponse<Cart> response = await _mediator.Send(request);

            if(response.IsSuccess)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response); 
            }

            return result;
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateCartDto request)
        {
            IActionResult result;
            HandlerResponse<Cart> response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(DeleteCartDto request)
        {
            IActionResult result;
            HandlerResponse<Cart> response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                result = Ok(response);
            }
            else
            {
                result = BadRequest(response);
            }

            return result;
        }
    }
}
