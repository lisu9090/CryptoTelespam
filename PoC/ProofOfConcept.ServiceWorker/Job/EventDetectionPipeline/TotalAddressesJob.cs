using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class TotalAddressesJob : FullPipelineJobBase
    {
        public TotalAddressesJob(
            IStockEventPipeline pipeline,
            ILogger<TotalAddressesJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.TotalAddresses;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc, AssetId.Eth };
    }
}