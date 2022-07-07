using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateCategoryDtoHandler : BaseHandler, IRequestHandler<CreateCategoryDto, HandlerResponse<Category>>
    {
        public CreateCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Category>> Handle(CreateCategoryDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Category> result = null;
            try
            {
                result = await _unitOfWork._categoryRepository.Add(
                    new Category
                    {
                        Name = request.Name,
                        Cart = _unitOfWork._cartRepository.GetByIdAsync(request.CartId).Result
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            return new HandlerResponse<Category>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
