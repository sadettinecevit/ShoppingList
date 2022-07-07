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
            List<Group> group = _unitOfWork._groupRepository.GetAsync().Result.ToList();

            HandlerResponse<List<GetByIdGroupResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdGroupResponseDto>>();

            if (group != null)
            {
                foreach (Group item in group)
                {
                    IQueryable<Product> products = _unitOfWork._productRepository.GetAsync().Result.Where(I=>I.Group == item).AsQueryable();
                    
                    handlerResponse.Data.Add(new GetByIdGroupResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        CreateTime = item.CreateTime,
                        CompeleteTime = item.CompeleteTime,
                        ProductList = products
                    });
                }
            }

            return handlerResponse;
        }
    }
}
