using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetUserDto : FilteredPageQuery, IRequest<HandlerResponse<List<GetByIdUserResponseDto>>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
