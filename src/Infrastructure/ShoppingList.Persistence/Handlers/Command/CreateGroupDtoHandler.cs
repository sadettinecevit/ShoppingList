using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateGroupDtoHandler : BaseHandler, IRequestHandler<CreateGroupDto, HandlerResponse<Group>>
    {
        public CreateGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Group>> Handle(CreateGroupDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Group> result = null;
            try
            {
                result =
                await _unitOfWork._groupRepository.Add(
                    new Group
                    {
                        Name = request.Name,
                        Category = _unitOfWork._categoryRepository.GetByIdAsync(request.CategoryId).Result
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            return new HandlerResponse<Group>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
