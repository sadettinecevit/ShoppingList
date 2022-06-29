using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetCategoryDto : FilteredPageQuery, IRequest<IQueryable<GetByIdCategoryResponseDto>>
    {
    }

}
