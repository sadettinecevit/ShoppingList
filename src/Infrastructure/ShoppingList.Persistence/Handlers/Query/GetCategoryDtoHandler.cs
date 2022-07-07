using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetCategoryDtoHandler : BaseHandler, IRequestHandler<GetCategoryDto, HandlerResponse<List<GetByIdCategoryResponseDto>>>
    {
        public GetCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<List<GetByIdCategoryResponseDto>>> Handle(GetCategoryDto request, CancellationToken cancellationToken)
        {
            List<Category> category = await _unitOfWork._categoryRepository.GetAsync();

            HandlerResponse<List<GetByIdCategoryResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdCategoryResponseDto>>();
            handlerResponse.IsSuccess = category != null;

            if (category != null)
            {
                foreach (Category item in category)
                {
                    IQueryable<Group> groups = _unitOfWork._groupRepository.GetAsync().Result.AsQueryable();
                    handlerResponse.Data.Add(new GetByIdCategoryResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreateTime = item.CreateTime,
                        CompeleteTime = item.CompeleteTime,
                        ShoppingGroup = groups
                    });
                }
            }

            return handlerResponse;
        }
    }
}
