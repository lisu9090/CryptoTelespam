using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NewAddressesEventDetectorService : IDataProcessorService<NewAddresses>
    {
        public Task<StockEvent<NewAddresses>> DetectEventAsync(NewAddresses data)
        {
            return Task.FromResult<StockEvent<NewAddresses>>(null); //todo
        }
    }
}
