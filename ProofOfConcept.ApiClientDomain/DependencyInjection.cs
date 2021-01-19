using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProofOfConcept.ApiClientDomain
{
    public static class DependencyInjection
    {
        public static void RegisterApiClients(this IServiceCollection services)
        {
            //services.AddScoped<IDataLoaderService<NuplEntity>, NuplLoaderService>();
        }
    }
}
