using Microsoft.Extensions.Configuration;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    static class TriggerConfiguration
    {
        private const string QUARTZ_TRIGGER_CONFIG = "QuartzTriggers:";
        private const string QUARTZ_TRIGGER_DEFAULT_CONFIG = "0 0 * ? * *";
        public static void RegisterTriggers(this IServiceCollectionQuartzConfigurator quartzTriggers, IConfiguration config)
        {
            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.LTH_NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.LthNuplKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG + "LthNupl", QUARTZ_TRIGGER_DEFAULT_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.MARKET_CAP_TRIGGER_KEY)
            .ForJob(KeyConfiguration.MarketCapKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG + "MarketCap", QUARTZ_TRIGGER_DEFAULT_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.NuplKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG + "Nupl", QUARTZ_TRIGGER_DEFAULT_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.PUELL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.PuellKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG + "Puell", QUARTZ_TRIGGER_DEFAULT_CONFIG)));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.STF_TRIGGER_KEY)
            .ForJob(KeyConfiguration.StfDeflectionKey)
            .StartNow()
            .WithCronSchedule(config.GetValue(QUARTZ_TRIGGER_CONFIG + "Stf", QUARTZ_TRIGGER_DEFAULT_CONFIG)));

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
