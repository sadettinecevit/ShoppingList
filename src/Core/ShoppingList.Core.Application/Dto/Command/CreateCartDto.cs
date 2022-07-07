using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateCartDto : IRequest<HandlerResponse<Cart>>
	{
		public string OwnerUsername { get; set; } // username
	}

}
