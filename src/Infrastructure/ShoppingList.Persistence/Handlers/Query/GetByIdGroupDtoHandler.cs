using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetByIdGroupDtoHandler : BaseHandler, IRequestHandler<GetByIdGroupDto, HandlerResponse<GetByIdGroupResponseDto>>
    {
        public GetByIdGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<GetByIdGroupResponseDto>> Handle(GetByIdGroupDto request, CancellationToken cancellationToken)
        {
            Group group = await _unitOfWork._groupRepository.GetByIdAsync(request.Id);

            HandlerResponse<GetByIdGroupResponseDto> handlerResponse = new HandlerResponse<GetByIdGroupResponseDto>();
            handlerResponse.IsSuccess = group != null;

            if (group != null)
            {
                handlerResponse.Data = new GetByIdGroupResponseDto()
                {
                    Id = group.Id,
                    Name = group.Name,
                    CreateTime = group.CreateTime,
                    CompeleteTime = group.CompeleteTime,
                    ProductList = _unitOfWork._productRepository.GetAsync().Result.Where(I=>I.Group.Id == group.Id).AsQueryable()
                };
            }

            return handlerResponse;
        }
    }
}
