using System.Threading.Tasks;
using Domain.Dtos.Auth;
using Domain.Interfaces.Services.User;
using Domain.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthResult> LoginAsync([FromBody] LoginDto login) {
            return await _authService.LoginAsync(login);
        }
    }
}
