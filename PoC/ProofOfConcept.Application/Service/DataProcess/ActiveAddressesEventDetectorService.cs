using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessorService<ActiveAddresses>
    {
        public ZoneChageEvent<ActiveAddresses> DetectEvent(ActiveAddresses data)
        {
            return null; //todo
        }
    }
}