using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services.User;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
        public async Task<IEnumerable<UserEntity>> ListAsync() {
            return await _userService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserEntity> GetAsync(Guid id) {
            return await _userService.GetAsync(id);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] UserEntity user) {
            await _userService.CreateAsync(user);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, [FromBody] UserEntity user) {
            user.Id = id;
            await _userService.UpdateAsync(user);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsyc(Guid id) {
            await _userService.DeleteAsync(id);
        }
    }
}
