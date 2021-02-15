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
    class ActiveAddressesJob : FullPipelineJob<NewAddresses>
    {
        public ActiveAddressesJob(IDataLoaderService<NewAddresses> dataLoaderService, 
            IDataProcessorService<NewAddresses> dataProcessorService,
            IMessageSenderService<NewAddresses> messageSenderService, 
            ILogger<FullPipelineJob<NewAddresses>> logger) : base(dataLoaderService, 
                dataProcessorService,
                messageSenderService, 
                logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}
