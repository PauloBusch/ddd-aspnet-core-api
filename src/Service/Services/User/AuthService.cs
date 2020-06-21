using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories.User;
using Domain.Interfaces.Services.User;

namespace Service.Services.User
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<object> FindByEmail(UserEntity user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email)) return null;
            return await _userRepository.FindByEmailAsync(user.Email);
        }
    }
}
