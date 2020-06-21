using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureDatabase
    {
        public static void ConfigureDependencyDatabases(IServiceCollection serviceCollection) {
            serviceCollection.AddDbContext<DDDContext>(options => 
                options.UseInMemoryDatabase("tests")
            );
        }
    }
}
