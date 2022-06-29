using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetUserDto : FilteredPageQuery, IRequest<IQueryable<GetByIdUserResponseDto>>
    {
    }

}
