using MediatR;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateCartDto : IRequest<int>
	{
		public IQueryable<Category> ShoppingCategory { get; set; }
	}

}
