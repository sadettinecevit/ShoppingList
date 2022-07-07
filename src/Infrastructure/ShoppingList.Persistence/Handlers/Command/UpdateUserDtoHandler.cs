using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Domain.Entities;
using System.Diagnostics;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class UpdateUserDtoHandler : IRequestHandler<UpdateUserDto, HandlerResponse<User>>
    {
        private readonly UserManager<User> _userManager;
        public UpdateUserDtoHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandlerResponse<User>> Handle(UpdateUserDto request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.Id);
            IdentityResult identityResult = null;

            try
            {
                user.Email = request.Email ?? user.Email;
                user.Name = request.Name ?? user.Name;
                user.LastName = request.Lastname ?? user.LastName;
                user.UserName = request.Username ?? user.UserName;

                identityResult = await _userManager.UpdateAsync(user);

                if (identityResult.Succeeded)
                {
                    _userManager.ChangePasswordAsync(user, request.OldPassword, request.Password);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            return new HandlerResponse<User>()
            {
                IsSuccess = identityResult.Succeeded,
                Data = identityResult.Succeeded ? user : null
            };
        }
    }
}
