using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class NuplJob : FullPipelineJobBase<Nupl>
    {
        public NuplJob(IDataLoaderService<Nupl> dataLoaderService,
            IDataProcessorService<Nupl> dataProcessorService,
            IMessageSenderService<Nupl> messageSenderService,
            ILogger<NuplJob> logger)
            : base(dataLoaderService,
                  dataProcessorService,
                  messageSenderService,
                  logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}