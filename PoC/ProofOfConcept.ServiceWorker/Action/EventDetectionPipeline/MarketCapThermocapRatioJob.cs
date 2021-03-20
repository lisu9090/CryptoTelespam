using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Domain;
using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Common.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action
{
    class MarketCapThermocapRatioJob : FullPipelineJobBase<MarketCapThermocapRatio>
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
