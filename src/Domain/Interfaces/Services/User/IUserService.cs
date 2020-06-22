using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Dtos.User;
using Domain.ViewModels.User;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetAsync(Guid id);
        Task<IEnumerable<UserListViewModel>> ListAsync();
        Task CreateAsync(UserDto user);
        Task UpdateAsync(UserDto user);
        Task DeleteAsync(Guid id);
    }
}
