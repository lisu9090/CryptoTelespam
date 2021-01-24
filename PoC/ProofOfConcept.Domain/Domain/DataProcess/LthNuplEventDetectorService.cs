using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class LthNuplEventDetectorService : IDataProcessorService<ILthNupl>
    {
        public Task<bool> DetectEventAsync(ILthNupl data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
