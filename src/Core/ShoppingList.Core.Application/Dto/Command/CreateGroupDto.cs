using MediatR;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateGroupDto : IRequest<int>
	{
		public string Name { get; set; }
		public IQueryable<Product> ProductList { get; set; }
	}

}
