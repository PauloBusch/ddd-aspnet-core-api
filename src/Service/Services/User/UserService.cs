using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.User;
using Domain.Interfaces.Services.User;

namespace Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> GetAsync(Guid id)
        {
            return await _userRepository.GetAsync(id); 
        }

        public async Task<IEnumerable<UserEntity>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task CreateAsync(UserEntity user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserEntity user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
