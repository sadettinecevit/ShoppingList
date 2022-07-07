using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.Repositories;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateCartDtoHandler : BaseHandler, IRequestHandler<CreateCartDto, HandlerResponse<Cart>>
    {
        public CreateCartDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<Cart>> Handle(CreateCartDto request, CancellationToken cancellationToken)
        {
            User owner = await _unitOfWork._userManager.FindByNameAsync(request.OwnerUsername);

            RepositoryResponse<Cart> result = null;
            try
            {
                result = new RepositoryResponse<Cart>();
                if (owner != null)
                {
                    result = await _unitOfWork._cartRepository.Add(new Cart { Owner = owner });
                }
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
