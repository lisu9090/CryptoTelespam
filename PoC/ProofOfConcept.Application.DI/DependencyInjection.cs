using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.DataLoad;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Application.Service.DataProcess;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Application.Service.MessageSend;
using ProofOfConcept.Application.Service.MessageSend.Abstract;

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
            services.AddTransient<IDataProcessorFactory<float>, DataProcessorFactory>();
            services.AddTransient<IDataProcessorFactory<int>, DataProcessorFactory>();
            services.AddTransient<IDataProcessor<float>, NuplEventDetectorService>();
            services.AddTransient<IDataProcessor<float>, PuellEventDetectorService>();
            services.AddTransient<IDataProcessor<float>, LthNuplEventDetectorService>();
            services.AddTransient<IDataProcessor<float>, MarketCapThermocapRatioEventDetectorService>();
            services.AddTransient<IDataProcessor<float>, StfDeflectionEventDetectorService>();
            services.AddTransient<IDataProcessor<float>, MvrvZScoreEventDetectorService>();
            services.AddTransient<IDataProcessor<int>, NewAddressesEventDetectorService>();
            services.AddTransient<IDataProcessor<int>, TotalAddressesEventDetectorService>();
            services.AddTransient<IDataProcessor<int>, ActiveAddressesEventDetectorService>();
        }

        private static void RegisterMessageSendServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageSenderFactory<float>, MessageSenderFactory>();
            services.AddTransient<IMessageSenderFactory<int>, MessageSenderFactory>();
            services.AddTransient<IMessageSender<float>, NuplMessageService>();
            services.AddTransient<IMessageSender<float>, PuellMessageService>();
            services.AddTransient<IMessageSender<float>, LthNuplMessageService>();
            services.AddTransient<IMessageSender<float>, MarketCapThermocapRatioMessageService>();
            services.AddTransient<IMessageSender<float>, StfDeflectionMessageService>();
            services.AddTransient<IMessageSender<float>, MvrvZScoreMessageService>();
            services.AddTransient<IMessageSender<int>, NewAddressesMessageService>();
            services.AddTransient<IMessageSender<int>, TotalAddressesMessageService>();
            services.AddTransient<IMessageSender<int>, ActiveAddressesMessageService>();
        }
    }
}