using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    public class DeleteCategoryDto : IRequest<HandlerResponse<Category>>
	{
		public string Id { get; set; }
	}

}
