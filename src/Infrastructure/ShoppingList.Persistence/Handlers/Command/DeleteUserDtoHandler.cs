﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Domain.Entities;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class DeleteUserDtoHandler : IRequestHandler<DeleteUserDto, HandlerResponse<User>>
    {
        private readonly UserManager<User> _userManager;
        public DeleteUserDtoHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<HandlerResponse<User>> Handle(DeleteUserDto request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.Id);
            var identityResult = await _userManager.DeleteAsync(user);

            return new HandlerResponse<User>()
            {
                IsSuccess = identityResult.Succeeded,
                Data = identityResult.Succeeded ? user : null
            };
        }
    }
}
