using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Arch_Prototype.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Arch_Prototype.Application.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            if (ValidateCredentials(user))
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    }
                );

                var created = DateTime.Now;
                var expiration = created +
                                 TimeSpan.FromSeconds(3600);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "",
                    Audience = "",
                    // todo: verify and implement SigningCredentials
                    // SigningCredentials = new SigningCredentials(),
                    Subject = identity,
                    NotBefore = created,
                    Expires = expiration
                });
                var token = handler.WriteToken(securityToken);

                var response = new
                {
                    authenticated = true,
                    created = created.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expiration.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
                
                return Ok(response);
            }
            else
            {
                var response = new
                {
                    authenticated = false,
                    message = "Failed to attempt to authenticate"
                };
                
                return Unauthorized(response.message);
            }
        }

        private static bool ValidateCredentials(LoginViewModel user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email)) return false;

            var userBase = new User
            {
                Email = "admin@admin.com",
                Password = "12356"
            };

            return user.Email == userBase.Email &&
                   user.Password == userBase.Password;
        }
    }
}