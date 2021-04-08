using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Abstract.Database;
using System;

namespace ProofOfConcept.Database.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services.AddTransient<IAssetRepository, TestRepo>();

            return services;
        }
    }
}