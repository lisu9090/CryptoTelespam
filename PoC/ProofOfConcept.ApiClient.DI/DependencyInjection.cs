﻿using Microsoft.Extensions.Configuration;
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
            services.AddHttpClient();

            services.AddTransient<IRestApiService, GlassNodeApiService>(sp => 
                new GlassNodeApiService(configuration.GetValue("Api:GlassNode:Timeout", DEFAULT_TIMEOUT),
                    configuration["Api:GlassNode:BaseUrl"],
                    configuration["Api:GlassNode:ApiKeyParamName"],
                    configuration["Api:GlassNode:Key"],
                    sp.GetRequiredService<HttpClient>(),
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
