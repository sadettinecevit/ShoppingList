using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetCartDto : FilteredPageQuery, IRequest<HandlerResponse<List<GetByIdCartResponseDto>>>
    {
        public string Id { get; set; } = string.Empty;
    }
}
