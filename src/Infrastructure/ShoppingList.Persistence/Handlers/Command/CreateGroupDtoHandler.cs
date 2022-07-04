using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateGroupDtoHandler : BaseHandler, IRequestHandler<CreateGroupDto, HandlerResponse<Group>>
    {
        public CreateGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Group>> Handle(CreateGroupDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Group> result = await _unitOfWork._groupRepository.Add(new Group { Name = request.Name, ProductList = request.ProductList });
            return new HandlerResponse<Group>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
