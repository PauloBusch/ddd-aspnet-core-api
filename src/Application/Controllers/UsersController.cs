using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services.User;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using Domain.Dtos.User;
using Domain.ViewModels.User;

namespace Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserListViewModel>> ListAsync() {
            return await _userService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserDetailViewModel> GetAsync(Guid id) {
            return await _userService.GetAsync(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task CreateAsync([FromBody] UserDto dto) {
            await _userService.CreateAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, [FromBody] UserDto dto) {
            dto.Id = id;
            await _userService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsyc(Guid id) {
            await _userService.DeleteAsync(id);
        }
    }
}
