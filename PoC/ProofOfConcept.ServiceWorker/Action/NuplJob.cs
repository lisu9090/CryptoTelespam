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
    class NuplJob : FullPipelineJob<Nupl>
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
