using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Indicator;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class ActiveAddressesJob : FullPipelineJobBase<ActiveAddresses>
    {
        public ActiveAddressesJob(IDataLoaderService<ActiveAddresses> dataLoaderService,
            IDataProcessorService<ActiveAddresses> dataProcessorService,
            IMessageSenderService<ActiveAddresses> messageSenderService,
            ILogger<ActiveAddressesJob> logger) : base(dataLoaderService,
                dataProcessorService,
                messageSenderService,
                logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}