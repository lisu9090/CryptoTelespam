using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.AbstractDomain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class LthNuplEventDetectorService : IDataProcessorService<LthNupl>
    {
        public Task<bool> DetectEventAsync(LthNupl data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
