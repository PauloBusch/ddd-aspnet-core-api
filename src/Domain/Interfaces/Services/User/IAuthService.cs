using System.Threading.Tasks;
using Domain.Dtos.User;
using Domain.Entities;

namespace Domain.Interfaces.Services.User
{
    public interface IAuthService
    {
        Task<object> LoginAsync(LoginDto login);
    }
}
