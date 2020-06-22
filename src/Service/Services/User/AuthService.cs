using System;
using System.Security.Principal;
using System.Security.Claims;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Repositories.User;
using Domain.Interfaces.Services.User;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Domain.ViewModels.Auth;
using Domain.Dtos.Auth;

namespace Service.Services.User
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;

        public AuthService(
            IUserRepository userRepository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration
        ) {
            _userRepository = userRepository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<AuthResult> LoginAsync(LoginDto login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Email)) return new AuthResult { Authenticated = false, Message = "Login fail" };
            var user = await _userRepository.FindByEmailAsync(login.Email);
            if (user == null) return new AuthResult { Authenticated = false, Message = "Login fail" };
            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Email),
                new [] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                }
            );
            var now = DateTime.Now;
            var expire = now.AddSeconds(_tokenConfiguration.Seconds);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.Credentials,
                Subject = identity,
                NotBefore = now,
                Expires = expire
            });
            var tokenStr = handler.WriteToken(securityToken);
            return new AuthResult{
                Authenticated = true,
                Creation = now,
                Expiration = expire,
                AccessToken = tokenStr,
                UserName = user.Name,
                Message = "Login successfully"
            };
        }
    }
}
