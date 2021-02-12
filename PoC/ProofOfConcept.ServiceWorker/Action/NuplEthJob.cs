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
    class NuplEthJob : FullPipelineJob<Nupl>
    {
        public NuplEthJob(IDataLoaderService<Nupl> dataLoaderService, 
            IDataProcessorService<Nupl> dataProcessorService, 
            IMessageSenderService<Nupl> messageSenderService) 
            : base(dataLoaderService, 
                  dataProcessorService, 
                  messageSenderService, 
                  CryptocurrencySymbol.ETH)
        {
        }
    }
}
