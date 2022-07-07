using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateCategoryDto : IRequest<HandlerResponse<Category>>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime CompeleteTime { get; set; }
		public string? CartId { get; set; }
	}

}
