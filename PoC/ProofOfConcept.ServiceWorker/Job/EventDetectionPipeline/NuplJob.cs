using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class NuplJob : FullPipelineJobBase
    {
        public NuplJob(
            IStockEventPipeline pipeline,
            ILogger<NuplJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.Nupl;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc, AssetId.Eth };
    }
}