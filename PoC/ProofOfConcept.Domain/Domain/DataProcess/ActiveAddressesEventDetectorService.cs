using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessorService<ActiveAddresses>
    {
        public Task<StockEvent<ActiveAddresses>> DetectEventAsync(ActiveAddresses data)
        {
            return Task.FromResult<StockEvent<ActiveAddresses>>(null); //todo
        }
    }
}
