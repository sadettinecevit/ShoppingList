using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateGroupDtoHandler : BaseHandler, IRequestHandler<UpdateGroupDto, HandlerResponse<Group>>
    {
        public UpdateGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Group>> Handle(UpdateGroupDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Group> result = await _unitOfWork._groupRepository.Update(
                new Group
                {
                    CompeleteTime = request.CompeleteTime,
                    Name = request.Name,
                    ProductList = request.ProductList
                });

            return new HandlerResponse<Group>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
