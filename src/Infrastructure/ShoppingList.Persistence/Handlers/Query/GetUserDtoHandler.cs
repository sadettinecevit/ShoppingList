using MediatR;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Query;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Query
{
    public class GetUserDtoHandler : BaseHandler, IRequestHandler<GetUserDto, HandlerResponse<List<GetByIdUserResponseDto>>>
    {
        public GetUserDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<HandlerResponse<List<GetByIdUserResponseDto>>> Handle(GetUserDto request, CancellationToken cancellationToken)
        {
            List<User> users = await _unitOfWork._userRepository.GetAsync();

            HandlerResponse<List<GetByIdUserResponseDto>> handlerResponse = new HandlerResponse<List<GetByIdUserResponseDto>>();
            handlerResponse.IsSuccess = users != null;

            if (users != null)
            {
                handlerResponse.Data = new List<GetByIdUserResponseDto>();
                foreach (User item in users)
                {
                    handlerResponse.Data.Add(new GetByIdUserResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Lastname = item.LastName,
                        Email = item.Email
                    });
                }
            }

            return handlerResponse;
        }
    }
}
