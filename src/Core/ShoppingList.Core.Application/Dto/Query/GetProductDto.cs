using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetProductDto : FilteredPageQuery, IRequest<IQueryable<GetByIdProductResponseDto>>
    {
    }

}
