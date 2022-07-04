using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetProductDto : FilteredPageQuery, IRequest<HandlerResponse<List<GetByIdProductResponseDto>>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
