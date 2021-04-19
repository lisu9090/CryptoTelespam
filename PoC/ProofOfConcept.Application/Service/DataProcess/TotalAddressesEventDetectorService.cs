using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class TotalAddressesEventDetectorService : IDataProcessorService<TotalAddresses>
    {
        public ZoneChageEvent<TotalAddresses> DetectEvent(TotalAddresses data)
        {
            return null; //todo
        }
    }
}