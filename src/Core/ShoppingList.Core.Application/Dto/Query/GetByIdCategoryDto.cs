using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCategoryDto : FilteredPageQuery, IRequest<GetByIdCategoryResponseDto>
    {
    }

}
