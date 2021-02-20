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
        public static void RegisterTriggers(this IServiceCollectionQuartzConfigurator quartzTriggers)
        {
            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.ACTIVE_ADDRESSES_TRIGGER_KEY)
            .ForJob(KeyConfiguration.ActiveAddressesKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever())
                //.WithDescription("my awesome simple trigger")
                );

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.LTH_NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.LthNuplKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.MARKET_CAP_TRIGGER_KEY)
            .ForJob(KeyConfiguration.MarketCapKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.NEW_ADDRESSES_TRIGGER_KEY)
            .ForJob(KeyConfiguration.NewAddressesKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.NuplKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.STF_TRIGGER_KEY)
            .ForJob(KeyConfiguration.StfDeflectionKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.TOTAL_ADDRESSES_TRIGGER_KEY)
            .ForJob(KeyConfiguration.TotalAddressesKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever()));
        }
    }
}
