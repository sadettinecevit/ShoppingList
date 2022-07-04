using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCategoryDto : FilteredPageQuery, IRequest<HandlerResponse<GetByIdCategoryResponseDto>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
