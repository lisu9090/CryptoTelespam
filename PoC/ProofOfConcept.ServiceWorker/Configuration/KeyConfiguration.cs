using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    static class KeyConfiguration
    {
        public const string FULL_PIPELINE_GROUP = "full-pipeline-jobs";
        
        public const string NUPL_JOB_KEY = "nupl-job";
        
        public const string NUPL_TRIGGER_KEY = "nupl-trigger";

        public static JobKey NuplKey 
        { 
            get 
            {
                return new JobKey(NUPL_JOB_KEY, FULL_PIPELINE_GROUP);
            } 
        }
    }
}
