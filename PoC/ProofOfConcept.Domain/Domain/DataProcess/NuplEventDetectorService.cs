using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        public Task<StockEvent<Nupl>> DetectEventAsync(Nupl data)
        {
            throw new System.NotImplementedException();
        }
    }
}
