using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class ActiveAddressesJob : FullPipelineJobBase
    {
        public ActiveAddressesJob(
            IZoneChangeEventPipeline pipeline,
            ILogger<ActiveAddressesJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.ActiveAddresses;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc, AssetId.Eth };
    }
}