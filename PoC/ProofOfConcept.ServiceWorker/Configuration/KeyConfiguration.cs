using Quartz;

namespace ProofOfConcept.ServiceWorker.Configuration
{
    internal static class KeyConfiguration
    {
        public const string FULL_PIPELINE_GROUP = "full-pipeline-job-group";

        public const string ACTIVE_ADDRESSES_JOB_KEY = "active-addresses-job";
        public const string LTH_NUPL_JOB_KEY = "lth-nupl-job";
        public const string MARKET_CAP_JOB_KEY = "market-cap-thermocap-ratio-job";
        public const string NEW_ADDRESSES_JOB_KEY = "new-addresses-job";
        public const string NUPL_JOB_KEY = "nupl-job";
        public const string PUELL_JOB_KEY = "puell-job";
        public const string STF_JOB_KEY = "stf-deflection-job";
        public const string TOTAL_ADDRESSES_JOB_KEY = "total-addresses-job";

        public const string ACTIVE_ADDRESSES_TRIGGER_KEY = ACTIVE_ADDRESSES_JOB_KEY + "-trigger";
        public const string LTH_NUPL_TRIGGER_KEY = LTH_NUPL_JOB_KEY + "-trigger";
        public const string MARKET_CAP_TRIGGER_KEY = MARKET_CAP_JOB_KEY + "-trigger";
        public const string NEW_ADDRESSES_TRIGGER_KEY = NEW_ADDRESSES_JOB_KEY + "-trigger";
        public const string NUPL_TRIGGER_KEY = NUPL_JOB_KEY + "-trigger";
        public const string PUELL_TRIGGER_KEY = PUELL_JOB_KEY + "-trigger";
        public const string STF_TRIGGER_KEY = STF_JOB_KEY + "-trigger";
        public const string TOTAL_ADDRESSES_TRIGGER_KEY = TOTAL_ADDRESSES_JOB_KEY + "-trigger";

        public static JobKey ActiveAddressesKey => new JobKey(ACTIVE_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey LthNuplKey => new JobKey(LTH_NUPL_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey MarketCapKey => new JobKey(MARKET_CAP_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey NewAddressesKey => new JobKey(NEW_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey NuplKey => new JobKey(NUPL_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey PuellKey => new JobKey(PUELL_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey StfDeflectionKey => new JobKey(STF_JOB_KEY, FULL_PIPELINE_GROUP);

        public static JobKey TotalAddressesKey => new JobKey(TOTAL_ADDRESSES_JOB_KEY, FULL_PIPELINE_GROUP);
    }
}