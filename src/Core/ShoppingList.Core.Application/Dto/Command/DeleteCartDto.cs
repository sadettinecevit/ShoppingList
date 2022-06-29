using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteCartDto : IRequest<int>
	{
		public string Id { get; set; }
	}

}
