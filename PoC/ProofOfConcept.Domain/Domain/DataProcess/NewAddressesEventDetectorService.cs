using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class NewAddressesEventDetectorService : IDataProcessorService<NewAddresses>
    {
        public Task<bool> DetectEventAsync(NewAddresses data)
        {
            return Task.FromResult(true); //todo
        }
    }
}
