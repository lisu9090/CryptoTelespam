using Microsoft.Extensions.Configuration;
using Quartz;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    internal static class TriggerConfiguration
    {
        private const string QUARTZ_TRIGGER_CONFIG_PATH = "QuartzTriggers:";
        private const string DEFAULT_QUARTZ_TRIGGER_CONFIG = "0 0 * ? * *";

        public static void RegisterTriggers(this IServiceCollectionQuartzConfigurator quartzTriggers, IConfiguration config)
        {
            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.LTH_NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.LthNuplKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG_PATH + "LthNupl", DEFAULT_QUARTZ_TRIGGER_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.MARKET_CAP_TRIGGER_KEY)
            .ForJob(KeyConfiguration.MarketCapKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG_PATH + "MarketCap", DEFAULT_QUARTZ_TRIGGER_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.NuplKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG_PATH + "Nupl", DEFAULT_QUARTZ_TRIGGER_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.PUELL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.PuellKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG_PATH + "Puell", DEFAULT_QUARTZ_TRIGGER_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.STF_TRIGGER_KEY)
            .ForJob(KeyConfiguration.StfDeflectionKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG_PATH + "Stf", DEFAULT_QUARTZ_TRIGGER_CONFIG)));

            //quartzTriggers.AddTrigger(t => t
            //.WithIdentity(KeyConfiguration.TOTAL_ADDRESSES_TRIGGER_KEY)
            //.ForJob(KeyConfiguration.TotalAddressesKey)
            //.StartNow()
            //.WithSimpleSchedule(x =>
            //    x.WithInterval(TimeSpan.FromSeconds(15))
            //    .RepeatForever()));

            //quartzTriggers.AddTrigger(t => t
            //.WithIdentity(KeyConfiguration.NEW_ADDRESSES_TRIGGER_KEY)
            //.ForJob(KeyConfiguration.NewAddressesKey)
            //.StartNow()
            //.WithSimpleSchedule(x =>
            //    x.WithInterval(TimeSpan.FromSeconds(15))
            //    .RepeatForever()));

            //quartzTriggers.AddTrigger(t => t
            //.WithIdentity(KeyConfiguration.ACTIVE_ADDRESSES_TRIGGER_KEY)
            //.ForJob(KeyConfiguration.ActiveAddressesKey)
            //.StartNow()
            //.WithSimpleSchedule(x =>
            //    x.WithInterval(TimeSpan.FromSeconds(15))
            //    .RepeatForever())
            //    //.WithDescription("my awesome simple trigger")
            //    );
        }
    }
}