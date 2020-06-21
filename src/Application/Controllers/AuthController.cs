using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Services.User;
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
        public async Task<object> LoginAsync([FromBody] LoginDto login) {
            return await _authService.LoginAsync(login);
        }
    }
}
