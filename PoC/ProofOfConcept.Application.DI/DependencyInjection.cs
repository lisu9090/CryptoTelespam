using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Service.DataLoad;
using ProofOfConcept.Application.Service.DataProcess;
using ProofOfConcept.Application.Service.MessageSend;
using ProofOfConcept.Domain;

namespace ProofOfConcept.DomainWorker
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.RegisterDataLoadServices();
            services.RegisterDataProcessServices();
            services.RegisterMessageSendServices();
        }

        private static void RegisterDataLoadServices(this IServiceCollection services)
        {
            services.AddTransient<IDataLoaderService<Nupl>, NuplLoaderService>();
            services.AddTransient<IDataLoaderService<Puell>, PuellLoaderService>();
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
            services.AddTransient<IDataProcessorService<Puell>, PuellEventDetectorService>();
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
            services.AddTransient<IMessageSenderService<Puell>, PuellMessageService>();
            services.AddTransient<IMessageSenderService<NewAddresses>, NewAddressesMessageService>();
            services.AddTransient<IMessageSenderService<TotalAddresses>, TotalAddressesMessageService>();
            services.AddTransient<IMessageSenderService<ActiveAddresses>, ActiveAddressesMessageService>();
            services.AddTransient<IMessageSenderService<LthNupl>, LthNuplMessageService>();
            services.AddTransient<IMessageSenderService<MarketCapThermocapRatio>, MarketCapThermocapRatioMessageService>();
            services.AddTransient<IMessageSenderService<StfDeflection>, StfDeflectionMessageService>();
        }
    }
}