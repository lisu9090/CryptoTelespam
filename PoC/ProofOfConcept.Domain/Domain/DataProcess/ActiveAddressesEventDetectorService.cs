using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Abstract.Application;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessorService<ActiveAddresses>
    {
        public StockEvent<ActiveAddresses> DetectEvent(ActiveAddresses data)
        {
            return null; //todo
        }
    }
}
