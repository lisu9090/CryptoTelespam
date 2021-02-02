using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class StfDeflectionEventDetectorService : IDataProcessorService<StfDeflection>
    {
        public Task<StockEvent<StfDeflection>> DetectEventAsync(StfDeflection data)
        {
            throw new System.NotImplementedException();
        }
    }
}
