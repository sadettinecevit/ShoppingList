using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateUserDtoHandler : IRequestHandler<CreateUserDto, HandlerResponse<User>>
    {
        private readonly UserManager<User> _userManager;
        public CreateUserDtoHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandlerResponse<User>> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(
                new User
                {
                    Name = request.Name,
                    LastName = request.Lastname,
                    Email = request.Email
                }, request.Password);

            return new HandlerResponse<User>()
            {
                IsSuccess = result.Succeeded,
                Data = _userManager.FindByEmailAsync(request.Email).Result
            };
        }
    }
}
