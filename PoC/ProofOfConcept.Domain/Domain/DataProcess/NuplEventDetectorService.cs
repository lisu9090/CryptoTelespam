using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;
using ProofOfConcept.Domain.Abstract;
using ProofOfConcept.Domain.Domain.NuplLevelChange;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        public Task<StockEvent<Nupl>> DetectEventAsync(Nupl data)
        {
            return Task.Run(() => 
            {
                //INuplLevelChangeDetector decoratedDetector = new CapitulationLevelDetector();

                return (StockEvent<Nupl>)null;
            });
        }
    }
}
