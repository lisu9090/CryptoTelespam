using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.AbstractApiClient;
using ProofOfConcept.ApiClient.Service;
using System.Net.Http;

namespace ProofOfConcept.ApiClientDomain
{
    public static class DependencyInjection
    {
        public static void RegisterApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddTransient<IRestApiService, GlassNodeApiService>(serviceProvider => 
                new GlassNodeApiService(int.Parse(configuration["Api:Timeout"]),
                    configuration["Api:BaseUrl"],
                    configuration["Api:ApiKeyParamName"],
                    configuration["Api:Key"],
                    serviceProvider.GetRequiredService<HttpClient>()));

            services.AddTransient<IMessageApiService, TestConsoleMessageApiService>();
        }
    }
}
