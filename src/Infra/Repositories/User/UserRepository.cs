using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories.User;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DDDContext context) : base(context) { }

        public async Task<UserEntity> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstAsync(u => u.Email == email);
        }
    }
}
