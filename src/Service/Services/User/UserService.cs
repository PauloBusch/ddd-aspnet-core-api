using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.User;
using Domain.Interfaces.Services.User;
using Domain.ViewModels.User;

namespace Service.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper    
        ) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDetailViewModel>(user);
        }

        public async Task<IEnumerable<UserListViewModel>> ListAsync()
        {
            var users = await _userRepository.ListAsync();
            return _mapper.ProjectTo<UserListViewModel>(users.AsQueryable());
        }

        public async Task CreateAsync(UserDto dto)
        {
            var user = _mapper.Map<UserEntity>(dto);
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = _mapper.Map<UserEntity>(dto);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
