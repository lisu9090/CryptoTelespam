using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessorService<StfDeflection>
    {
        public Task<bool> DetectEventAsync(StfDeflection data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
