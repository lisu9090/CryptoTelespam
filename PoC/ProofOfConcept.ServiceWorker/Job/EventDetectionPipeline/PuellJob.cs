using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class PuellJob : FullPipelineJobBase
    {
        public PuellJob(
            IStockEventPipeline pipeline,
            ILogger<PuellJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.Puell;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc };
    }
}