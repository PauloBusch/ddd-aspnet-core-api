using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories.User
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByEmailAsync(string email);
    }
}
