using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetGroupDto : FilteredPageQuery, IRequest<IQueryable<GetByIdGroupResponseDto>>
    {
    }

}
