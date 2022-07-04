using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetGroupDtoHandler : BaseHandler, IRequestHandler<GetGroupDto, HandlerResponse<List<GetByIdGroupResponseDto>>>
    {
        public GetGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<List<GetByIdGroupResponseDto>>> Handle(GetGroupDto request, CancellationToken cancellationToken)
        {
            List<Group> group = await _unitOfWork._groupRepository.GetAsync();

            HandlerResponse<List<GetByIdGroupResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdGroupResponseDto>>();
            handlerResponse.IsSuccess = group != null;

            if (group != null)
            {
                foreach (Group item in group)
                {
                    handlerResponse.Data.Add(new GetByIdGroupResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreateTime = item.CreateTime,
                        CompeleteTime = item.CompeleteTime,
                        ProductList = item.ProductList
                    });
                }
            }

            return handlerResponse;
        }
    }
}
