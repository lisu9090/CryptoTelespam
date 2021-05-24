using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class StfDeflectionJob : FullPipelineJobBase
    {
        public StfDeflectionJob(
            IStockEventPipeline pipeline,
            ILogger<StfDeflectionJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.StfDeflection;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc };
    }
}