using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateGroupDtoHandler : BaseHandler, IRequestHandler<UpdateGroupDto, HandlerResponse<Group>>
    {
        public UpdateGroupDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Group>> Handle(UpdateGroupDto request, CancellationToken cancellationToken)
        {
            string categoryId = string.IsNullOrWhiteSpace(request.CategoryId) ?
                _unitOfWork._groupRepository.GetByIdAsync(request.Id).Result.Id :
                request.CategoryId;
            RepositoryResponse<Group> result = null;
            try
            {
                result = await _unitOfWork._groupRepository.Update(
                new Group
                {
                    Id = request.Id,
                    CompeleteTime = request.CompeleteTime,
                    Name = request.Name,
                    Category = _unitOfWork._categoryRepository.GetByIdAsync(categoryId).Result
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
