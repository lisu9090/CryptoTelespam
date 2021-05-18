using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Abstract.Database;

namespace ProofOfConcept.Database.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services.AddTransient<IAssetRepository, AssetRepository>();
            services.AddTransient<IIndicatorRepository, IndicatorRepository>();
            services.AddTransient<IMessageTemplateRepository, MessageTemplateRepository>();
            services.AddTransient<IZoneRepository, ZoneRepository>();

            return services;
        }
    }
}