using MediatR;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateCartDto : IRequest<int>
	{
		public User Owner { get; set; }
		public IQueryable<Category> ShoppingCategory { get; set; }
	}

}
