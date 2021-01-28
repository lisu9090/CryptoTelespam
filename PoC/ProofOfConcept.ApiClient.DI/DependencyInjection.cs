using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.ApiClient.Service;
using System.Net.Http;

namespace ProofOfConcept.ApiClientDomain
{
    public static class DependencyInjection
    {
        public static void RegisterApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddTransient<IRestApiService, GlassNodeApiService>(sp => 
                new GlassNodeApiService(int.Parse(configuration["Api:GlassNode:Timeout"]),
                    configuration["Api:GlassNode:BaseUrl"],
                    configuration["Api:GlassNode:ApiKeyParamName"],
                    configuration["Api:GlassNode:Key"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<ILogger<GlassNodeApiService>>()));

            services.AddTransient<IMessageApiService, TelegramMessageApiService>(sp =>
                new TelegramMessageApiService(int.Parse(configuration["Api:Telegram:Timeout"]),
                    configuration["Api:Telegram:BaseUrl"],
                    configuration["Api:Telegram:MessageTargetParamName"],
                    configuration["Api:Telegram:MessageTarget"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<ILogger<TelegramMessageApiService>>()));
        }
    }
}
