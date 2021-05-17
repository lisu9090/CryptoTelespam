using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.IndicatorTmp;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class LthNuplJob : FullPipelineJobBase<LthNupl>
    {
        public LthNuplJob(IDataLoaderService<LthNupl> dataLoaderService,
            IDataProcessorService<LthNupl> dataProcessorService,
            IMessageSenderService<LthNupl> messageSenderService,
            ILogger<LthNuplJob> logger)
            : base(dataLoaderService,
                  dataProcessorService,
                  messageSenderService,
                  logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC };
        }
    }
}