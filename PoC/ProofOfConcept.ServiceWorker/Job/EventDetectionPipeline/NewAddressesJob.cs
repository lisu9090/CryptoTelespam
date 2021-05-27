﻿using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain.Enum;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class NewAddressesJob : FullPipelineJobBase
    {
        public NewAddressesJob(
            IZoneChangeEventPipeline pipeline,
            ILogger<NewAddressesJob> logger)
            : base(pipeline, logger)
        {
        }

        protected override IndicatorId IndicatorId => IndicatorId.NewAddresses;

        protected override IEnumerable<AssetId> Assets => new AssetId[] { AssetId.Btc, AssetId.Eth };
    }
}