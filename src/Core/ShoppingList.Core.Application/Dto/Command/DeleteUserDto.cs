using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteUserDto : IRequest<HandlerResponse<User>>
	{
		public string Id { get; set; }
	}

}
