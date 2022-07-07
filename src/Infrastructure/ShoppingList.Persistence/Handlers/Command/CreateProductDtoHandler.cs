using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateProductDtoHandler : BaseHandler, IRequestHandler<CreateProductDto, HandlerResponse<Product>>
    {
        public CreateProductDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Product>> Handle(CreateProductDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Product> result = null;
            try
            {
                result = await _unitOfWork._productRepository.Add(
                new Product
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Price = request.Price,
                    Quantity = request.Quantity
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }

            return new HandlerResponse<Product>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
