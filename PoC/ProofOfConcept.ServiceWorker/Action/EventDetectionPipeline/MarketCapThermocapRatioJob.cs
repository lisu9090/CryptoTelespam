using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Action.EventDetectionPipeline
{
    internal class MarketCapThermocapRatioJob : FullPipelineJobBase<MarketCapThermocapRatio>
    {
        public MarketCapThermocapRatioJob(IDataLoaderService<MarketCapThermocapRatio> dataLoaderService,
            IDataProcessorService<MarketCapThermocapRatio> dataProcessorService,
            IMessageSenderService<MarketCapThermocapRatio> messageSenderService,
            ILogger<MarketCapThermocapRatioJob> logger)
            : base(dataLoaderService,
                  dataProcessorService,
                  messageSenderService,
                  logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}