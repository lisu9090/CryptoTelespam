using Microsoft.Extensions.Logging;
using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Common.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Action.EventDetectionPipeline
{
    class LthNuplJob : FullPipelineJobBase<LthNupl>
    {
        public LthNuplJob(IDataLoaderService<LthNupl> dataLoaderService, 
            IDataProcessorService<LthNupl> dataProcessorService, 
            IMessageSenderService<LthNupl> messageSenderService,
            ILogger<LthNuplJob> logger) 
            : base(dataLoaderService, 
                  dataProcessorService, 
                  messageSenderService,
                  logger)
        {
            _cryptocurrencySymbols = new List<string> { CryptocurrencySymbol.BTC };
        }
    }
}
