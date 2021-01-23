using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NewAddressesEventDetectorService : IDataProcessorService<INewAddresses>
    {
        public Task<bool> DetectEventAsync(INewAddresses data)
        {
            return Task.FromResult(true); //todo
        }
    }
}
