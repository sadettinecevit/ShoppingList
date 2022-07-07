using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class LoginDto : IRequest<HandlerResponse<LoginResponseDto>>
	{
		public string Username { get; set; }
        public string Password { get; set; }
    }


}
