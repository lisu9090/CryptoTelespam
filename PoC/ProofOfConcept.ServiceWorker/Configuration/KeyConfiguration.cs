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
        public const string FULL_PIPELINE_GROUP = "full-pipeline-job-group";
        
        public const string ACTIVE_ADDRESSES_JOB_KEY = "active-addresses-job";
        public const string LTH_NUPL_JOB_KEY = "lth-nupl-job";
        public const string MARKET_CAP_JOB_KEY = "market-cap-thermocap-ratio-job";
        public const string NEW_ADDRESSES_JOB_KEY = "new-addresses-job";
        public const string NUPL_JOB_KEY = "nupl-job";
        public const string STF_JOB_KEY = "stf-deflection-job";
        public const string TOTAL_ADDRESSES_JOB_KEY = "total-addresses-job";

        public const string ACTIVE_ADDRESSES_TRIGGER_KEY = ACTIVE_ADDRESSES_JOB_KEY + "-trigger";
        public const string LTH_NUPL_TRIGGER_KEY = LTH_NUPL_JOB_KEY + "-trigger";
        public const string MARKET_CAP_TRIGGER_KEY = MARKET_CAP_JOB_KEY + "-trigger";
        public const string NEW_ADDRESSES_TRIGGER_KEY = NEW_ADDRESSES_JOB_KEY + "-trigger";
        public const string NUPL_TRIGGER_KEY = NUPL_JOB_KEY + "-trigger";
        public const string STF_TRIGGER_KEY = STF_JOB_KEY + "-trigger";
        public const string TOTAL_ADDRESSES_TRIGGER_KEY = TOTAL_ADDRESSES_JOB_KEY + "-trigger";

        public static JobKey ActiveAddressesKey
        { 
            get 
            {
                return new JobKey(ACTIVE_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);
            } 
        }

        public static JobKey LthNuplKey
        {
            get
            {
                return new JobKey(LTH_NUPL_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }

        public static JobKey MarketCapKey
        {
            get
            {
                return new JobKey(MARKET_CAP_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }

        public static JobKey NewAddressesKey
        {
            get
            {
                return new JobKey(NEW_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }

        public static JobKey NuplKey
        {
            get
            {
                return new JobKey(NUPL_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }

        public static JobKey StfDeflectionKey
        {
            get
            {
                return new JobKey(STF_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }

        public static JobKey TotalAddressesKey
        {
            get
            {
                return new JobKey(TOTAL_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);
            }
        }
    }
}
