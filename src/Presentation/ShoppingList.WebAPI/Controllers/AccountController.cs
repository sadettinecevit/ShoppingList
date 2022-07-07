using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Domain.Entities;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]
    public class AccountController : ControllerBase
    {
        IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetUserDto request)
        {
            HandlerResponse<List<GetByIdUserResponseDto>> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getbyid/{id}")]
//        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdUserDto request)
        {
            HandlerResponse<GetByIdUserResponseDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDto request)
        {
            HandlerResponse<LoginResponseDto> response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserDto request)
        {
            IActionResult result;
            HandlerResponse<User> response = await _mediator.Send(request);

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
//        [Authorize(Policy = "RequireUserRole")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto request)
        {
            IActionResult result;
            HandlerResponse<User> response = await _mediator.Send(request);

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
//        [Authorize(Policy = "RequireUserRole")]
        public async Task<IActionResult> Delete(DeleteUserDto request)
        {
            IActionResult result;
            HandlerResponse<User> response = await _mediator.Send(request);

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
