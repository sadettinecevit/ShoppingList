using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetCartDto : FilteredPageQuery, IRequest<IQueryable<GetByIdCartResponseDto>>
    {
    }
}
