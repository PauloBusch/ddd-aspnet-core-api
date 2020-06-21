using Service.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.User;

namespace CrossCutting.injection
{
    public class ConfigureService
    {
        public static void ConfigureDependencyServices(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAuthService, AuthService>();
        }
    }
}
