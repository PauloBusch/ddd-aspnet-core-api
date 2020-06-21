using Domain.Interfaces.Repositories;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencyRepositories(IServiceCollection serviceCollection) {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
