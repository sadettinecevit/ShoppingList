using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdGroupDto : FilteredPageQuery, IRequest<GetByIdGroupResponseDto>
    {
    }

}
