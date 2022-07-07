using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateProductDtoHandler : BaseHandler, IRequestHandler<UpdateProductDto, HandlerResponse<Product>>
    {
        public UpdateProductDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Product>> Handle(UpdateProductDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Product> result = null;
            try
            {
                result
                = await _unitOfWork._productRepository.Update(
                new Product
                {
                    Brand = request.Brand,
                    IsTaken = request.IsTaken,
                    Name = request.Name,
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
