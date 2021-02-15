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
            .WithIdentity("nupl-trigger")
            .ForJob(nuplKey)
            .StartNow()
            .WithSimpleSchedule(x =>
                x.WithInterval(TimeSpan.FromSeconds(15))
                .RepeatForever())
                    //.WithDescription("my awesome simple trigger")
                );
        }
    }
}
