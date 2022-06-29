using MediatR;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteCategoryDto : IRequest<int>
	{
		public string Id { get; set; }
	}

}
