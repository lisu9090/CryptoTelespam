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
        private const int DEFAULT_TIMEOUT = 30;

        public static void RegisterApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            int timeout = DEFAULT_TIMEOUT;

            services.AddHttpClient();

            if (configuration.GetSection("Api:GlassNode:Timeout").Exists())
            {
                int.TryParse(configuration["Api:GlassNode:Timeout"], out timeout);
            }

            services.AddTransient<IRestApiService, GlassNodeApiService>(sp => 
                new GlassNodeApiService(timeout,
                    configuration["Api:GlassNode:BaseUrl"],
                    configuration["Api:GlassNode:ApiKeyParamName"],
                    configuration["Api:GlassNode:Key"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<ILogger<GlassNodeApiService>>()));

            if (configuration.GetSection("Api:Telegram:Timeout").Exists())
            {
                int.TryParse(configuration["Api:Telegram:Timeout"], out timeout);
            }
            else
            {
                timeout = DEFAULT_TIMEOUT;
            }

            services.AddTransient<IMessageApiService, TelegramMessageApiService>(sp =>
                new TelegramMessageApiService(timeout,
                    configuration["Api:Telegram:BaseUrl"],
                    configuration["Api:Telegram:MessageTargetParamName"],
                    configuration["Api:Telegram:MessageTarget"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<ILogger<TelegramMessageApiService>>()));
        }
    }
}
