using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateCartDto : IRequest<HandlerResponse<Cart>>
	{
		public IQueryable<Category> ShoppingCategory { get; set; }
	}

}
