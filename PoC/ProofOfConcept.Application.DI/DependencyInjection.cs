using Microsoft.Extensions.DependencyInjection;
using ProofOfConcept.Application.Service.DataLoad;
using ProofOfConcept.Application.Service.DataLoad.Abstract;
using ProofOfConcept.Application.Service.ZoneChange;
using ProofOfConcept.Application.Service.ZoneChange.Abstract;
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
            services.AddTransient<ZoneChangeDetectorFactory<float>, DataProcessorFactory>();
            services.AddTransient<ZoneChangeDetectorFactory<int>, DataProcessorFactory>();
            services.AddTransient<IZoneChangeDetector<float>, NuplEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<float>, PuellEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<float>, LthNuplZoneChangeDetectorService>();
            services.AddTransient<IZoneChangeDetector<float>, MarketCapThermocapRatioEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<float>, StfDeflectionEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<float>, MvrvZScoreEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<int>, NewAddressesEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<int>, TotalAddressesEventDetectorService>();
            services.AddTransient<IZoneChangeDetector<int>, ActiveAddressesEventDetectorService>();
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