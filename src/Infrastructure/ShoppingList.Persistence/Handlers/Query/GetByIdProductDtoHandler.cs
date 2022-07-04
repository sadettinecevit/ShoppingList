using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetByIdProductDtoHandler : BaseHandler, IRequestHandler<GetByIdProductDto, HandlerResponse<GetByIdProductResponseDto>>
    {
        public GetByIdProductDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<GetByIdProductResponseDto>> Handle(GetByIdProductDto request, CancellationToken cancellationToken)
        {
            Product product = await _unitOfWork._productRepository.GetByIdAsync(request.Id);

            HandlerResponse<GetByIdProductResponseDto> handlerResponse = new HandlerResponse<GetByIdProductResponseDto>();
            handlerResponse.IsSuccess = product != null;

            if (product != null)
            {
                handlerResponse.Data = new GetByIdProductResponseDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    IsTaken = product.IsTaken,
                    Price = product.Price,
                    Quantity = product.Quantity
                };
            }

            return handlerResponse;
        }
    }
}
