using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Common.Const;
using ProofOfConcept.Domain.Indicator;
using System.Collections.Generic;

namespace ProofOfConcept.ServiceWorker.Job.EventDetectionPipeline
{
    internal class TotalAddressesJob : FullPipelineJobBase<TotalAddresses>
    {
        public TotalAddressesJob(IDataLoaderService<TotalAddresses> dataLoaderService,
            IDataProcessorService<TotalAddresses> dataProcessorService,
            IMessageSenderService<TotalAddresses> messageSenderService,
            ILogger<TotalAddressesJob> logger) : base(dataLoaderService,
                dataProcessorService,
                messageSenderService,
                logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC, CryptocurrencySymbol.ETH };
        }
    }
}