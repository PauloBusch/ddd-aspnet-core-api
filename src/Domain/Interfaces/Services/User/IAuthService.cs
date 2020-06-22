using System.Threading.Tasks;
using Domain.Dtos.Auth;
using Domain.ViewModels.Auth;

namespace Domain.Interfaces.Services.User
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginDto login);
    }
}
