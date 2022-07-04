using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class CreateProductDto : IRequest<HandlerResponse<Product>>
	{
		public string Name { get; set; }
		public string Brand { get; set; }
		public float Quantity { get; set; }
		public decimal Price { get; set; }
		public bool IsTaken { get; set; }
	}
}
