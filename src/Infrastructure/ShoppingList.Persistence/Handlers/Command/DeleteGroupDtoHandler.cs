using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class DeleteGroupDtoHandler : BaseHandler, IRequestHandler<DeleteGroupDto, HandlerResponse<Group>>
    {
        public DeleteGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Group>> Handle(DeleteGroupDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Group> result = await _unitOfWork._groupRepository.Delete(
                new Group
                {
                    Id = request.Id
                });

            return new HandlerResponse<Group>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
