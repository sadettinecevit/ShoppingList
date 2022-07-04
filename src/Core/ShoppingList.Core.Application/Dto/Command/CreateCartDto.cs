using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateCartDto : IRequest<HandlerResponse<Cart>>
	{
		public User Owner { get; set; }
		public IQueryable<Category> ShoppingCategory { get; set; }
	}

}
