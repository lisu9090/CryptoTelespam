using Microsoft.Extensions.DependencyInjection;

namespace ProofOfConcept.Database.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            return services;
        }
    }
}