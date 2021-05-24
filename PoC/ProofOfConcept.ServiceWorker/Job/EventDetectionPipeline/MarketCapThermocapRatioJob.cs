using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class MarketCapThermocapRatioJob : FullPipelineJobBase
    {
        public MarketCapThermocapRatioJob(
            IStockEventPipeline pipeline,
            ILogger<MarketCapThermocapRatioJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.MarketCapThermocapRatio;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc, AssetId.Eth };
    }
}