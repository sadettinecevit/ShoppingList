using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdCartDto : FilteredPageQuery, IRequest<GetByIdCartResponseDto>
    {
    }

}
