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
    class NewAddressesJob : FullPipelineJobBase<NewAddresses>
    {
        public NewAddressesJob(IDataLoaderService<NewAddresses> dataLoaderService, 
            IDataProcessorService<NewAddresses> dataProcessorService,
            IMessageSenderService<NewAddresses> messageSenderService,
            ILogger<NewAddressesJob> logger) : base(dataLoaderService, 
                dataProcessorService,
                messageSenderService, 
                logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}
