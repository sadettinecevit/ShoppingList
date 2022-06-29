using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateProductDto : IRequest<int>
	{
		public string Name { get; set; }
		public string Brand { get; set; }
		public float Quantity { get; set; }
		public decimal Price { get; set; }
		public bool IsTaken { get; set; }
	}
}
