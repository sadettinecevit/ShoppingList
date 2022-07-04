using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetCartDtoHandler : BaseHandler, IRequestHandler<GetCartDto, HandlerResponse<List<GetByIdCartResponseDto>>>
    {
        public GetCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<List<GetByIdCartResponseDto>>> Handle(GetCartDto request, CancellationToken cancellationToken)
        {
            List<Cart> carts = await _unitOfWork._cartRepository.GetAsync();

            HandlerResponse<List<GetByIdCartResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdCartResponseDto>>();
            handlerResponse.IsSuccess = carts != null;

            if (carts != null)
            {
                foreach (Cart item in carts)
                {
                    handlerResponse.Data.Add(new GetByIdCartResponseDto
                    {
                        Id = item.Id,
                        CreateTime = item.CreateTime,
                        Owner = item.Owner,
                        ShoppingCategory = item.ShoppingCategory
                    });
                }
            }

            return handlerResponse;
        }
    }
}
