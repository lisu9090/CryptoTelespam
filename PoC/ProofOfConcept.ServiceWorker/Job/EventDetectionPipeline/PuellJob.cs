using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class PuellJob : FullPipelineJobBase<Puell>
    {
        public PuellJob(IDataLoaderService<Puell> dataLoaderService,
            IDataProcessorService<Puell> dataProcessorService,
            IMessageSenderService<Puell> messageSenderService,
            ILogger<PuellJob> logger)
            : base(dataLoaderService,
                  dataProcessorService,
                  messageSenderService,
                  logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC };
        }
    }
}