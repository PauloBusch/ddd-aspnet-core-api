using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services.User;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _respository;

        public UserService(IRepository<UserEntity> repository) {
            _respository = repository;
        }

        public async Task<UserEntity> GetAsync(Guid id)
        {
            return await _respository.GetAsync(id); 
        }

        public async Task<IEnumerable<UserEntity>> ListAsync()
        {
            return await _respository.ListAsync();
        }

        public async Task CreateAsync(UserEntity user)
        {
            await _respository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserEntity user)
        {
            await _respository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _respository.DeleteAsync(id);
        }
    }
}
