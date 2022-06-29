using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteProductDto : IRequest<int>
	{
		public string Id { get; set; }
	}
}
