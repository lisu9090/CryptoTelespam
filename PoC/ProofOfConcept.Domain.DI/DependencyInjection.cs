using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.ApiClientDomain;
using ProofOfConcept.Domain.Domain.DataLoad;
using ProofOfConcept.Domain.Domain.DataProcess;
using ProofOfConcept.Domain.Domain.MessageSend;

namespace ProofOfConcept.DomainWorker
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.RegisterDataLoadServices();
            services.RegisterDataProcessServices();
            services.RegisterMessageSendServices();

            services.AddAutoMapper(typeof(ApiClientToDomainProfile));
        }

        private static void RegisterDataLoadServices(this IServiceCollection services)
        {
            services.AddTransient<IDataLoaderService<Nupl>, NuplLoaderService>();
            services.AddTransient<IDataLoaderService<NewAddresses>, NewAddressesLoaderService>();
            services.AddTransient<IDataLoaderService<TotalAddresses>, TotalAddressesLoaderService>();
            services.AddTransient<IDataLoaderService<ActiveAddresses>, ActiveAddressesLoaderService>();
            services.AddTransient<IDataLoaderService<LthNupl>, LthNuplLoaderService>();
            services.AddTransient<IDataLoaderService<MarketCapThermocapRatio>, MarketCapThermocapRatioLoaderService>();
            services.AddTransient<IDataLoaderService<StfDeflection>, StfDeflectionLoaderService>();
        }

        private static void RegisterDataProcessServices(this IServiceCollection services)
        {
            services.AddTransient<IDataProcessorService<Nupl>, NuplEventDetectorService>();
            services.AddTransient<IDataProcessorService<NewAddresses>, NewAddressesEventDetectorService>();
            services.AddTransient<IDataProcessorService<TotalAddresses>, TotalAddressesEventDetectorService>();
            services.AddTransient<IDataProcessorService<ActiveAddresses>, ActiveAddressesEventDetectorService>();
            services.AddTransient<IDataProcessorService<LthNupl>, LthNuplEventDetectorService>();
            services.AddTransient<IDataProcessorService<MarketCapThermocapRatio>, MarketCapThermocapRatioEventDetectorService>();
            services.AddTransient<IDataProcessorService<StfDeflection>, StfDeflectionEventDetectorService>();
        }

        private static void RegisterMessageSendServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageSenderService<Nupl>, NuplMessageService>();
        }
    }
}
