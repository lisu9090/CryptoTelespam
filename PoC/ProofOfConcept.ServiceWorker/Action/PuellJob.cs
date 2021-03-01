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
    class PuellJob : FullPipelineJob<Puell>
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
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}
