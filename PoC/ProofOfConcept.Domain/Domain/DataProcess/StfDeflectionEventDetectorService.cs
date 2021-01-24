using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessorService<IStfDeflection>
    {
        public Task<bool> DetectEventAsync(IStfDeflection data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
