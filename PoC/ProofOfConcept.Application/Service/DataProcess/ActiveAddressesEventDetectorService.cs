using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessorService<ActiveAddresses>
    {
        public StockEvent<ActiveAddresses> DetectEvent(ActiveAddresses data)
        {
            return null; //todo
        }
    }
}