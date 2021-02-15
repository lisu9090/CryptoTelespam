using ProofOfConcept.ServiceWorker.Action;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    static class JobConfiguration
    {
        public static void RegisterJobs(this IServiceCollectionQuartzConfigurator quartzJobs)
        {
            var nuplKey = new JobKey("nupl-eth", "nupl");
            quartzJobs.AddJob<NuplJob>(j => j
                .StoreDurably()
                .WithIdentity(nuplKey)
            //.WithDescription("my awesome job")
            );
        }
    }
}
