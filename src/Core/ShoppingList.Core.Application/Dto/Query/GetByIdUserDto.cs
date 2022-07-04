using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdUserDto : FilteredPageQuery, IRequest<HandlerResponse<GetByIdUserResponseDto>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
