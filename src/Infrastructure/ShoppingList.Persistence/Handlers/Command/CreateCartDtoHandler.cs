using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateCartDtoHandler : BaseHandler, IRequestHandler<CreateCartDto, HandlerResponse<Cart>>
    {
        public CreateCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<Cart>> Handle(CreateCartDto request, CancellationToken cancellationToken)
        {
            RepositoryResponse<Cart> result = await _unitOfWork._cartRepository.Add(new Cart { Owner = request.Owner, ShoppingCategory = request.ShoppingCategory });
            return new HandlerResponse<Cart>()
            {
                IsSuccess = result.TotalRecordCount > 0,
                Data = result.Entity
            };
        }
    }
}
