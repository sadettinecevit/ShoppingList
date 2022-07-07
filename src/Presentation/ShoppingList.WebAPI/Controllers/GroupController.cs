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
    public class GroupController : ControllerBase
    {
        IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetGroupDto request)
        {
            HandlerResponse<List<GetByIdGroupResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdGroupDto request)
        {
            HandlerResponse<GetByIdGroupResponseDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Add([FromBody] CreateGroupDto request)
        {
            IActionResult result;
            HandlerResponse<Group> response = await _mediator.Send(request);

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
        public async Task<IActionResult> Update(string id, [FromBody] UpdateGroupDto request)
        {
            IActionResult result;
            HandlerResponse<Group> response = await _mediator.Send(request);

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
        public async Task<IActionResult> Delete(DeleteGroupDto request)
        {
            IActionResult result;
            HandlerResponse<Group> response = await _mediator.Send(request);

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
