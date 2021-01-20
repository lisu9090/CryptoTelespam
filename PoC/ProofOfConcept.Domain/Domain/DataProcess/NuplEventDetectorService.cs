using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<INupl>
    {
        public Task<bool> DetectEventAsync(INupl data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
