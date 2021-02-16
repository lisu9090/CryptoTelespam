using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class TotalAddressesEventDetectorService : IDataProcessorService<TotalAddresses>
    {
        public Task<StockEvent<TotalAddresses>> DetectEventAsync(TotalAddresses data)
        {
            return Task.FromResult<StockEvent<TotalAddresses>>(null); //todo
        }
    }
}
