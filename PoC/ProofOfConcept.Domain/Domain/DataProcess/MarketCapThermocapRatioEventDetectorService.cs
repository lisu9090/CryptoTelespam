using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.AbstractDomain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class MarketCapThermocapRatioEventDetectorService : IDataProcessorService<MarketCapThermocapRatio>
    {
        public Task<bool> DetectEventAsync(MarketCapThermocapRatio data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
