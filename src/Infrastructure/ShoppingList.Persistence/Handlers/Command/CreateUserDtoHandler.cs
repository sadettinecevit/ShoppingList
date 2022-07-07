using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Application.Interfaces.UnitOfWork;
using ShoppingList.Domain.Entities;
using System.Diagnostics;
using System.Security.Claims;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class CreateUserDtoHandler : BaseHandler, IRequestHandler<CreateUserDto, HandlerResponse<User>>
    {
        public CreateUserDtoHandler(IUnitOfWorkService unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<HandlerResponse<User>> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            User user = null;
            bool checkRoleExist = await _unitOfWork._roleManager.RoleExistsAsync(request.Role);
            bool result = false;
            try
            {
                if (!checkRoleExist)
                {
                    var role = new IdentityRole();
                    role.Name = request.Role;
                    checkRoleExist = _unitOfWork._roleManager.CreateAsync(role).Result.Succeeded;
                }

                if (checkRoleExist)
                {
                    result = _unitOfWork._userManager.CreateAsync(
                                    new User
                                    {
                                        UserName = request.Username,
                                        Name = request.Name,
                                        LastName = request.Lastname,
                                        Email = request.Email
                                    }, request.Password).Result.Succeeded;

                    if (result)
                    {
                        user = _unitOfWork._userManager.FindByNameAsync(request.Username).Result;
                        result = _unitOfWork._userManager.AddToRoleAsync(user, request.Role).Result.Succeeded;

                        user = result ? user : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }

            return new HandlerResponse<User>()
            {
                IsSuccess = result,
                Data = user
            };
        }
    }
}
