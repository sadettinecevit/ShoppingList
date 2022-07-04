using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateCategoryDtoHandler : BaseHandler, IRequestHandler<CreateCategoryDto, HandlerResponse<Category>>
    {
        public CreateCategoryDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Category>> Handle(CreateCategoryDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Category> result = await _unitOfWork._categoryRepository.Add(new Category { Name = request.Name, ShoppingGroup = request.ShoppingGroup });
            return new HandlerResponse<Category>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
