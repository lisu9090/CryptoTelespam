using ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline;
using Quartz;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    internal static class JobConfiguration
    {
        public static void RegisterJobs(this IServiceCollectionQuartzConfigurator quartzJobs)
        {
            quartzJobs.AddJob<ActiveAddressesJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.ActiveAddressesKey));

            quartzJobs.AddJob<LthNuplJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.LthNuplKey));

            quartzJobs.AddJob<MarketCapThermocapRatioJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.MarketCapKey));

            quartzJobs.AddJob<NewAddressesJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.NewAddressesKey));

            quartzJobs.AddJob<NuplJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.NuplKey));

            quartzJobs.AddJob<PuellJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.PuellKey));

            quartzJobs.AddJob<StfDeflectionJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.StfDeflectionKey));

            quartzJobs.AddJob<TotalAddressesJob>(job => job
                .StoreDurably()
                .WithIdentity(KeyConfiguration.TotalAddressesKey));
        }
    }
}