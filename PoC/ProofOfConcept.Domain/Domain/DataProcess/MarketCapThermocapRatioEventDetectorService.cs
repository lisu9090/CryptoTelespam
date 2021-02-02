using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class MarketCapThermocapRatioEventDetectorService : IDataProcessorService<MarketCapThermocapRatio>
    {
        public Task<StockEvent<MarketCapThermocapRatio>> DetectEventAsync(MarketCapThermocapRatio data)
        {
            return Task.FromResult<StockEvent<MarketCapThermocapRatio>>(null);
        }
    }
}
