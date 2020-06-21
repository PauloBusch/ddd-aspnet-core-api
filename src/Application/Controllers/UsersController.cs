using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services.User;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserEntity>> GetUsersAsync() {
            return await _userService.ListAsync();
        }
    }
}
