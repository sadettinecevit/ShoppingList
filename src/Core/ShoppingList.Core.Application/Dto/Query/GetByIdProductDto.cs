using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdProductDto : FilteredPageQuery, IRequest<HandlerResponse<GetByIdProductResponseDto>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
