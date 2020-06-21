using Service.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureService
    {
        public static void ConfigureDependencyServices(IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
