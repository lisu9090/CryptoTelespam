using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class LthNuplJob : FullPipelineJobBase
    {
        public LthNuplJob(
            IStockEventPipeline pipeline,
            ILogger<LthNuplJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.LthNupl;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc };
    }
}