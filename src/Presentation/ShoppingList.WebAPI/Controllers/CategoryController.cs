using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Domain.Entities;

namespace ShoppingList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetCategoryDto request)
        {
            HandlerResponse<List<GetByIdCategoryResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCategoryDto request)
        {
            HandlerResponse<GetByIdCategoryResponseDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryDto request)
        {
            IActionResult result;
            HandlerResponse<Category> response = await _mediator.Send(request);

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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateCategoryDto request)
        {
            IActionResult result;
            HandlerResponse<Category> response = await _mediator.Send(request);

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
        public async Task<IActionResult> Delete(DeleteCategoryDto request)
        {
            IActionResult result;
            HandlerResponse<Category> response = await _mediator.Send(request);

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
