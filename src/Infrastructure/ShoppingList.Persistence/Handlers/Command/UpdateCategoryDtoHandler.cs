using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateCategoryDtoHandler : BaseHandler, IRequestHandler<UpdateCategoryDto, HandlerResponse<Category>>
    {
        public UpdateCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Category>> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Category> result = await _unitOfWork._categoryRepository.Update(
                new Category
                {
                    Name = request.Name,
                    CompeleteTime = request.CompeleteTime,
                    ShoppingGroup = request.ShoppingGroup
                });

            return new HandlerResponse<Category>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
