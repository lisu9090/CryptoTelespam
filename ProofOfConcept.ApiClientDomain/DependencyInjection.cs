using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.ApiClient.Service;

namespace ProofOfConcept.ApiClientDomain
{
    public static class DependencyInjection
    {
        public static void RegisterApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRestApiService, GlassNodeApiService>(); //todo add params
            services.AddScoped<IMessageApiService, TestConsoleMessageApiService>();
        }
    }
}
