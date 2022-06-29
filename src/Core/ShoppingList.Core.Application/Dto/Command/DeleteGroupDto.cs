using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteGroupDto : IRequest<int>
	{
		public string Id { get; set; }
	}

}
