using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteProductDto : IRequest<HandlerResponse<Product>>
	{
		public string Id { get; set; }
	}
}
