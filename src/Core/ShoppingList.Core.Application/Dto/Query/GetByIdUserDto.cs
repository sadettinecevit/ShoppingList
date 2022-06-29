using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdUserDto : FilteredPageQuery, IRequest<GetByIdUserResponseDto>
    {
    }

}
