using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class DeleteCartDtoHandler : BaseHandler, IRequestHandler<DeleteCartDto, HandlerResponse<Cart>>
    {
        public DeleteCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<Cart>> Handle(DeleteCartDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Cart> result = await _unitOfWork._cartRepository.Delete(
                new Cart
                {
                    Id = request.Id
                });

            return new HandlerResponse<Cart>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
