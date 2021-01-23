using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class TotalAddressesEventDetectorService : IDataProcessorService<ITotalAddresses>
    {
        public Task<bool> DetectEventAsync(ITotalAddresses data)
        {
            return Task.FromResult(true); //todo
        }
    }
}
