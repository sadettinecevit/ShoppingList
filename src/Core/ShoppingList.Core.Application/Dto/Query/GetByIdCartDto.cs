using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCartDto : IRequest<HandlerResponse<GetByIdCartResponseDto>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
