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
            .WithIdentity(KeyConfiguration.FULL_PIPELINE_TRIGGER_KEY)
            //.ForJob(KeyConfiguration.ActiveAddressesKey)
            //.ForJob(KeyConfiguration.LthNuplKey)
            //.ForJob(KeyConfiguration.MarketCapKey)
            //.ForJob(KeyConfiguration.NewAddressesKey)
            .ForJob(KeyConfiguration.NuplKey)
            //.ForJob(KeyConfiguration.StfDeflectionKey)
            //.ForJob(KeyConfiguration.TotalAddressesKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever())
                    //.WithDescription("my awesome simple trigger")
                );
        }
    }
}
