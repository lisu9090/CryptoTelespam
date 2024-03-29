﻿using ProofOfConcept.ServiceWorker.Action.EventDetectionPipeline;
using Quartz;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    static class JobConfiguration
    {
        public static void RegisterJobs(this IServiceCollectionQuartzConfigurator quartzJobs)
        {
            quartzJobs.AddJob<ActiveAddressesJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.ActiveAddressesKey)
                //.WithDescription("my awesome job")
            );

            quartzJobs.AddJob<LthNuplJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.LthNuplKey));

            quartzJobs.AddJob<MarketCapThermocapRatioJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.MarketCapKey));

            quartzJobs.AddJob<NewAddressesJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.NewAddressesKey));

            quartzJobs.AddJob<NuplJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.NuplKey));

            quartzJobs.AddJob<PuellJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.PuellKey));

            quartzJobs.AddJob<StfDeflectionJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.StfDeflectionKey));

            quartzJobs.AddJob<TotalAddressesJob>(j => j
                .StoreDurably()
                .WithIdentity(KeyConfiguration.TotalAddressesKey));
        }
    }
}
