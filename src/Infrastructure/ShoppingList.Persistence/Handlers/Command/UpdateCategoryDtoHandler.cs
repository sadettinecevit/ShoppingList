using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateCategoryDtoHandler : BaseHandler, IRequestHandler<UpdateCategoryDto, HandlerResponse<Category>>
    {
        public UpdateCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Category>> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
        {
            string CartId = string.IsNullOrWhiteSpace(request.CartId) ? _unitOfWork._cartRepository.GetByIdAsync(request.Id).Result.Id : request.CartId;
            RepositoryResponse<Category> result = null;
            try
            {
                result = await _unitOfWork._categoryRepository.Update(
                new Category
                {
                    Name = request.Name,
                    CompeleteTime = request.CompeleteTime,
                    Cart = _unitOfWork._cartRepository.GetByIdAsync(CartId).Result
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
