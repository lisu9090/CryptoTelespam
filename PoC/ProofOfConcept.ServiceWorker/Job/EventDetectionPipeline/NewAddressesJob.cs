using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class NewAddressesJob : FullPipelineJobBase<NewAddresses>
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