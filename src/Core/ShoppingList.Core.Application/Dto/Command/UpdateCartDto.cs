using MediatR;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Application.Dto.Command
{
    //gereksiz
    public class UpdateCartDto : IRequest<HandlerResponse<Cart>>
	{
        public string Id { get; set; }
        public string Username { get; set; }
    }

}
