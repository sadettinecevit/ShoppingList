using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetByIdGroupDto : FilteredPageQuery, IRequest<HandlerResponse<GetByIdGroupResponseDto>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
