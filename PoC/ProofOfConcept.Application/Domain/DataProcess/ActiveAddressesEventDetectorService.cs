using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

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