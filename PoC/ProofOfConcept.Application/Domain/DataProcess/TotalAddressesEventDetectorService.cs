using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Abstract.Application;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataProcess
{
    public class TotalAddressesEventDetectorService : IDataProcessorService<TotalAddresses>
    {
        public StockEvent<TotalAddresses> DetectEvent(TotalAddresses data)
        {
            return null; //todo
        }
    }
}
