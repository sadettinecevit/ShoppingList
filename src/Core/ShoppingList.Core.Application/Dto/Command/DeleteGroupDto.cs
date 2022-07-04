using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteGroupDto : IRequest<HandlerResponse<Group>>
	{
		public string Id { get; set; }
	}

}
