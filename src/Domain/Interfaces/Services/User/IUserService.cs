using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> GetAsync(Guid id);
        Task<IEnumerable<UserEntity>> ListAsync();
        Task CreateAsync(UserEntity user);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(Guid id);
    }
}
