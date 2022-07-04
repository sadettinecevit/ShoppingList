using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetByIdCartDtoHandler : BaseHandler, IRequestHandler<GetByIdCartDto, HandlerResponse<GetByIdCartResponseDto>>
    {
        public GetByIdCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<GetByIdCartResponseDto>> Handle(GetByIdCartDto request, CancellationToken cancellationToken)
        {
            Cart cart = await _unitOfWork._cartRepository.GetByIdAsync(request.Id);

            HandlerResponse<GetByIdCartResponseDto> handlerResponse = new HandlerResponse<GetByIdCartResponseDto>();
            handlerResponse.IsSuccess = cart != null;

            if (cart != null)
            {
                handlerResponse.Data = new GetByIdCartResponseDto()
                {
                    Id = cart.Id,
                    CreateTime = cart.CreateTime,
                    Owner = cart.Owner,
                    ShoppingCategory = cart.ShoppingCategory
                };
            }

            return handlerResponse;
        }
    }
}
