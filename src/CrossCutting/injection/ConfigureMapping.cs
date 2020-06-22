using CrossCutting.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.injection
{
    public class ConfigureMapping
    {
        public static void ConfigureDependencyMapping(IServiceCollection serviceCollection) {
            var config = new AutoMapper.MapperConfiguration(options => {
                options.AddProfile(new DtoToEntityProfile());
                options.AddProfile(new EntityToViewModelProfile());
            });
            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
}
