using ProofOfConcept.AbstractDomain;
using ProofOfConcept.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NuplEventDetectorService : IDataProcessorService<NuplEntity>
    {
        public Task<bool> DetectEventAsync(NuplEntity data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
