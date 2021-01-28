using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.AbstractDomain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<Nupl>
    {
        public Task<bool> DetectEventAsync(Nupl data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
