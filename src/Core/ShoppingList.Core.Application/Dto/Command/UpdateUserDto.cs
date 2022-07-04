using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateUserDto : IRequest<HandlerResponse<User>>
	{
        public string Id { get; set; }
        public string? Name { get; set; }
		public string? Lastname { get; set; }
		public string? Email { get; set; }
		public string? OldPassword { get; set; }
		public string? Password { get; set; }
	}

}
