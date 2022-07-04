using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetByIdCategoryDtoHandler : BaseHandler, IRequestHandler<GetByIdCategoryDto, HandlerResponse<GetByIdCategoryResponseDto>>
    {
        public GetByIdCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<GetByIdCategoryResponseDto>> Handle(GetByIdCategoryDto request, CancellationToken cancellationToken)
        {
            Category category = await _unitOfWork._categoryRepository.GetByIdAsync(request.Id);

            HandlerResponse<GetByIdCategoryResponseDto> handlerResponse = new HandlerResponse<GetByIdCategoryResponseDto>();
            handlerResponse.IsSuccess = category != null;

            if (category != null)
            {
                handlerResponse.Data = new GetByIdCategoryResponseDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreateTime = category.CreateTime,
                    CompeleteTime = category.CompeleteTime,
                    ShoppingGroup = category.ShoppingGroup
                };
            }

            return handlerResponse;
        }
    }
}
