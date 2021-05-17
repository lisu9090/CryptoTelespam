using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Domain.Zone.MarketCapZone;
using ProofOfConcept.Domain.Zone.NuplZone;
using ProofOfConcept.Domain.Zone.PuellZone;
using ProofOfConcept.Domain.Zone.StfDeflectionZone;

namespace ProofOfConcept.Domain.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
        {
            services.AddTransient<MarketCapZoneService>();
            services.AddTransient<NuplZoneService>();
            services.AddTransient<PuellZoneService>();
            services.AddTransient<StfDeflectionZoneService>();

            return services;
        }
    }
}