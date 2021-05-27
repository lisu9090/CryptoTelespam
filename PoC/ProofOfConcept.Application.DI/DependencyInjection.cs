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
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.RegisterDataLoadServices();
            services.RegisterDataProcessServices();
            services.RegisterMessageSendServices();
        }

        private static void RegisterDataLoadServices(this IServiceCollection services)
        {
            services.AddTransient<IIndicatorValueLoarder<Nupl>, NuplLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<Puell>, PuellLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<NewAddresses>, NewAddressesLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<TotalAddresses>, TotalAddressesLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<ActiveAddresses>, ActiveAddressesLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<LthNupl>, LthNuplLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<MarketCapThermocapRatio>, MarketCapThermocapRatioLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<StfDeflection>, StfDeflectionLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<MvrvRatio>, MvrvRatioLoaderService>();
            services.AddTransient<IIndicatorValueLoarder<MvrvZScore>, MvrvZScoreLoaderService>();
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
            services.AddTransient<IDataProcessorService<MvrvRatio>, MvrvRatioEventDetectorService>();
            services.AddTransient<IDataProcessorService<MvrvZScore>, MvrvZScoreEventDetectorService>();
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
            services.AddTransient<IMessageSenderService<MvrvRatio>, MvrvRatioMessageService>();
            services.AddTransient<IMessageSenderService<MvrvZScore>, MvrvZScoreMessageService>();
        }
    }
}