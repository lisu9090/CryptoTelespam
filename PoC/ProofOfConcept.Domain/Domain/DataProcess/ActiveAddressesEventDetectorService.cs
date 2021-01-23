using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessorService<IActiveAddresses>
    {
        public Task<bool> DetectEventAsync(IActiveAddresses data)
        {
            return Task.FromResult(true); //todo
        }
    }
}
