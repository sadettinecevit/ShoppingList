using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteCartDto : IRequest<HandlerResponse<Cart>>
	{
		public string Id { get; set; }
	}

}
