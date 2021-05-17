using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Indicator;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class StfDeflectionJob : FullPipelineJobBase<StfDeflection>
    {
        public StfDeflectionJob(IDataLoaderService<StfDeflection> dataLoaderService,
            IDataProcessorService<StfDeflection> dataProcessorService,
            IMessageSenderService<StfDeflection> messageSenderService,
            ILogger<StfDeflectionJob> logger) : base(dataLoaderService,
                dataProcessorService,
                messageSenderService,
                logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC };
        }
    }
}