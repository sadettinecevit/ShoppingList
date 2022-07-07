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
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetProductDto request)
        {
            HandlerResponse<List<GetByIdProductResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductDto request)
        {
            HandlerResponse<GetByIdProductResponseDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("create")]
//        [Authorize(Roles = "user")]
        public async Task<IActionResult> Add([FromBody] CreateProductDto request)
        {
            IActionResult result;
            HandlerResponse<Product> response = await _mediator.Send(request);

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
//        [Authorize(Roles ="user")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateProductDto request)
        {
            IActionResult result;
            HandlerResponse<Product> response = await _mediator.Send(request);

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
//        [Authorize(Roles = "user")]
        public async Task<IActionResult> Delete(DeleteProductDto request)
        {
            IActionResult result;
            HandlerResponse<Product> response = await _mediator.Send(request);

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
