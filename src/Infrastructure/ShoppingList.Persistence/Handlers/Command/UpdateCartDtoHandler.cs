using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateCartDtoHandler : BaseHandler, IRequestHandler<UpdateCartDto, HandlerResponse<Cart>>
    {
        public UpdateCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Cart>> Handle(UpdateCartDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Cart> result = await _unitOfWork._cartRepository.Update(
                new Cart
                {
                    ShoppingCategory = request.ShoppingCategory
                });

            return new HandlerResponse<Cart>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
