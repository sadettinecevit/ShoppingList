using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteUserDto : IRequest<int>
	{
		public string Id { get; set; }
	}

}
