using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetByIdUserDtoHandler : BaseHandler, IRequestHandler<GetByIdUserDto, HandlerResponse<GetByIdUserResponseDto>>
    {
        public GetByIdUserDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<GetByIdUserResponseDto>> Handle(GetByIdUserDto request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork._userRepository.GetByIdAsync(request.Id);

            HandlerResponse<GetByIdUserResponseDto> handlerResponse = new HandlerResponse<GetByIdUserResponseDto>();
            handlerResponse.IsSuccess = user != null;

            if (user != null)
            {
                handlerResponse.Data = new GetByIdUserResponseDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Lastname = user.LastName,
                    Email = user.Email
                };
            }

            return handlerResponse;
        }
    }
}
