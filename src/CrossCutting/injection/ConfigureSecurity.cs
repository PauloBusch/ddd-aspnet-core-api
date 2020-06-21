using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureSecurity
    {
        public static void ConfigureDependencySecurity(IServiceCollection serviceCollection, IConfiguration configuration) {
            serviceCollection.AddSingleton(new SigningConfiguration());
            serviceCollection.AddSingleton(configuration.GetSection("Token").Get<TokenConfiguration>());
        }
    }
}
