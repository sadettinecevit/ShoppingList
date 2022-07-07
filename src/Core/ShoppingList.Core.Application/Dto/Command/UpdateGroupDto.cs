using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class UpdateGroupDto : IRequest<HandlerResponse<Group>>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime? CompeleteTime { get; set; }
		public string? CategoryId { get; set; }
	}

}
