using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.DataLoad;
using ProofOfConcept.Application.Service.DataLoad.Abstract;

namespace ProofOfConcept.Application.DI
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
            services.AddTransient<IIndicatorValueLoaderFactory<float>, IndicatorValueLoaderFactory>();
            services.AddTransient<IIndicatorValueLoaderFactory<int>, IndicatorValueLoaderFactory>();
            services.AddTransient<IIndicatorValueLoader<float>, NuplLoaderService>();
            services.AddTransient<IIndicatorValueLoader<float>, PuellLoaderService>();
            services.AddTransient<IIndicatorValueLoader<float>, LthNuplLoaderService>();
            services.AddTransient<IIndicatorValueLoader<float>, MarketCapThermocapRatioLoaderService>();
            services.AddTransient<IIndicatorValueLoader<float>, StfDeflectionLoaderService>();
            services.AddTransient<IIndicatorValueLoader<float>, MvrvZScoreLoaderService>();
            services.AddTransient<IIndicatorValueLoader<int>, NewAddressesLoaderService>();
            services.AddTransient<IIndicatorValueLoader<int>, TotalAddressesLoaderService>();
            services.AddTransient<IIndicatorValueLoader<int>, ActiveAddressesLoaderService>();
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