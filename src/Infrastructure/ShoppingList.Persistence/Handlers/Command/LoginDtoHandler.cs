using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Application.Dto;
using ShoppingList.Application.Dto.Command;
using ShoppingList.Domain.Entities;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingList.Persistence.Handlers.Command
{
    public class LoginDtoHandler : IRequestHandler<LoginDto, HandlerResponse<LoginResponseDto>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public LoginDtoHandler(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<HandlerResponse<LoginResponseDto>> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            string token = string.Empty;
            List<Claim>? claims = new List<Claim>();

            User user = await _userManager.FindByNameAsync(request.Username);
            bool result = await _signInManager.CanSignInAsync(user);
            try
            {
                if (result)
                {
                    result = await _userManager.CheckPasswordAsync(user, request.Password);
                }
                if (result)
                {
                    await _signInManager.SignInAsync(user, result);
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    if (roles.Any())
                    {
                        foreach (string role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        claims.Add(new Claim(ClaimTypes.Name, request.Username));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        JwtSecurityToken jwt = GetToken(claims);

                        jwt = GetToken(claims);

                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                        token = handler.WriteToken(jwt);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw ex;
            }
            return new HandlerResponse<LoginResponseDto>()
            {
                IsSuccess = result,
                Data = new LoginResponseDto() { Username = request.Username, Token = token }
            };
        }

        private JwtSecurityToken GetToken(List<Claim> claims = null)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            JwtSecurityToken token = null;

            if (claims != null)
            {
                token = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    issuer: _configuration["JWT: Issuer"],
                    audience: _configuration["JWT: Audience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: claims
                    );
            }
            else
            {
                token = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                    issuer: _configuration["JWT: Issuer"],
                    audience: _configuration["JWT: Audience"],
                    expires: DateTime.Now.AddDays(1)
                    );
            }
            return token;
        }

    }
}
