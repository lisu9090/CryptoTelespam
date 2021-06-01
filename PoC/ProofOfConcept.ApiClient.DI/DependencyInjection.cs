using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.ApiClient;
using ProofOfConcept.ApiClient.MappingProfile;
using ProofOfConcept.ApiClient.Service;
using System.Net.Http;

namespace ProofOfConcept.ApiClient.DI
{
    public static class DependencyInjection
    {
        private const int DEFAULT_TIMEOUT = 30;

        public static void RegisterApiClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApiClientProfile));
            services.AddHttpClient();

            services.AddTransient<IRestApiService, GlassNodeApiService>(sp =>
                new GlassNodeApiService(configuration.GetValue("Api:GlassNode:Timeout", DEFAULT_TIMEOUT),
                    configuration["Api:GlassNode:BaseUrl"],
                    configuration["Api:GlassNode:ApiKeyParamName"],
                    configuration["Api:GlassNode:Key"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<IMapper>(),
                    sp.GetRequiredService<ILogger<GlassNodeApiService>>()));

            services.AddTransient<IMessageApiService, TelegramMessageApiService>(sp =>
                new TelegramMessageApiService(configuration.GetValue("Api:Telegram:Timeout", DEFAULT_TIMEOUT),
                    configuration["Api:Telegram:BaseUrl"],
                    configuration["Api:Telegram:MessageTargetParamName"],
                    configuration["Api:Telegram:MessageTarget"],
                    sp.GetRequiredService<HttpClient>(),
                    sp.GetRequiredService<ILogger<TelegramMessageApiService>>()));
        }
    }
}