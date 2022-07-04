using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetProductDtoHandler : BaseHandler, IRequestHandler<GetProductDto, HandlerResponse<List<GetByIdProductResponseDto>>>
    {
        public GetProductDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<List<GetByIdProductResponseDto>>> Handle(GetProductDto request, CancellationToken cancellationToken)
        {
            List<Product> products = await _unitOfWork._productRepository.GetAsync();

            HandlerResponse<List<GetByIdProductResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdProductResponseDto>>();
            handlerResponse.IsSuccess = products != null;

            if (products != null)
            {
                foreach (Product item in products)
                {
                    handlerResponse.Data.Add(new GetByIdProductResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Brand = item.Brand,
                        IsTaken = item.IsTaken,
                        Price = item.Price,
                        Quantity = item.Quantity
                    });
                }
            }

            return handlerResponse;
        }
    }
}
