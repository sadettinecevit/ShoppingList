using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdProductDto : FilteredPageQuery, IRequest<GetByIdProductResponseDto>
    {
    }

}
