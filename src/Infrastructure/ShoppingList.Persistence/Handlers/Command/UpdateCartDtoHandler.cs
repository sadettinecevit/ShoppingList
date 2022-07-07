using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateCartDtoHandler : BaseHandler, IRequestHandler<UpdateCartDto, HandlerResponse<Cart>>
    {
        public UpdateCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Cart>> Handle(UpdateCartDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Cart> result = null;
            try
            {
                result = await _unitOfWork._cartRepository.Update(
                new Cart
                {
                    Id = request.Id,
                    Owner = _unitOfWork._userManager.FindByNameAsync(request.Username).Result
                });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            return new HandlerResponse<Cart>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
