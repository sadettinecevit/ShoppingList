using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetCategoryDto : FilteredPageQuery, IRequest<HandlerResponse<List<GetByIdCategoryResponseDto>>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
