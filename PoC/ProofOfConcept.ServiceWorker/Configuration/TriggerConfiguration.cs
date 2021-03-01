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
        private const string QUARTZ_TRIGGER_CONFIG = "QuartzTriggers:Triggers:";
        private const string QUARTZ_TRIGGER_DEFAULT_CONFIG = "0 0 0/8 ? * *";
        public static void RegisterTriggers(this IServiceCollectionQuartzConfigurator quartzTriggers, IConfiguration config)
        { 
            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.LTH_NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.LthNuplKey)
            .StartNow()
            .WithCronSchedule(config.GetSectionOrDefault(QUARTZ_TRIGGER_CONFIG + "LthNupl")));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.MARKET_CAP_TRIGGER_KEY)
            .ForJob(KeyConfiguration.MarketCapKey)
            .StartNow()
            .WithCronSchedule(config.GetSectionOrDefault(QUARTZ_TRIGGER_CONFIG + "MarketCap")));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.NUPL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.NuplKey)
            .StartNow()
            .WithCronSchedule(config.GetSectionOrDefault(QUARTZ_TRIGGER_CONFIG + "Nupl")));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.PUELL_TRIGGER_KEY)
            .ForJob(KeyConfiguration.PuellKey)
            .StartNow()
            .WithCronSchedule(config.GetSectionOrDefault(QUARTZ_TRIGGER_CONFIG + "Puell")));

            quartzTriggers.AddTrigger(t => t
            .WithIdentity(KeyConfiguration.STF_TRIGGER_KEY)
            .ForJob(KeyConfiguration.StfDeflectionKey)
            .StartNow()
            .WithCronSchedule(config.GetSectionOrDefault(QUARTZ_TRIGGER_CONFIG + "Stf")));

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

        private static string GetSectionOrDefault(this IConfiguration config, string section)
        {
            return config.GetSection(section).Exists() ? config[section] : QUARTZ_TRIGGER_DEFAULT_CONFIG;
        }
    }
}
