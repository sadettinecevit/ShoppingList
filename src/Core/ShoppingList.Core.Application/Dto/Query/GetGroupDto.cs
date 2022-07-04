using MediatR;

namespace ShoppingList.Application.Dto.Query
{
    public class GetGroupDto : FilteredPageQuery, IRequest<HandlerResponse<List<GetByIdGroupResponseDto>>>
    {
        public string Id { get; set; } = string.Empty;
    }

}
