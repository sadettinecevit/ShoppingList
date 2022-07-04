using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateGroupDto : IRequest<HandlerResponse<Group>>
	{
		public string Name { get; set; }
		public IQueryable<Product> ProductList { get; set; }
	}

}
