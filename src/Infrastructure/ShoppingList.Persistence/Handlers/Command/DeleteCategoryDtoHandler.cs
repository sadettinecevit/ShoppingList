using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class DeleteCategoryDtoHandler : BaseHandler, IRequestHandler<DeleteCategoryDto, HandlerResponse<Category>>
    {
        public DeleteCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Category>> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Category> result = await _unitOfWork._categoryRepository.Delete(
                new Category
                {
                    Id = request.Id
                });

            return new HandlerResponse<Category>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
