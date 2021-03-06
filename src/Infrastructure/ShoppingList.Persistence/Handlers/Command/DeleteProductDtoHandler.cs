using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class DeleteProductDtoHandler : BaseHandler, IRequestHandler<DeleteProductDto, HandlerResponse<Product>>
    {
        public DeleteProductDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Product>> Handle(DeleteProductDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Product> result = null;
            try
            {
                result = await _unitOfWork._productRepository.Delete(
                    new Product
                    {
                        Id = request.Id
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
