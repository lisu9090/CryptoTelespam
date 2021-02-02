using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class LthNuplEventDetectorService : IDataProcessorService<LthNupl>
    {
        public Task<StockEvent<LthNupl>> DetectEventAsync(LthNupl data)
        {
            return Task.FromResult<StockEvent<LthNupl>>(null);
        }
    }
}
