using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.User;
using Infra.Repositories.User;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencyRepositories(IServiceCollection serviceCollection) {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
