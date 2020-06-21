using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services.User
{
    public interface IAuthService
    {
        Task<object> FindByEmail(UserEntity user);
    }
}
