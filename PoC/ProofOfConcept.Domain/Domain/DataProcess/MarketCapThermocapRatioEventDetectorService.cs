using ProofOfConcept.AbstractDomain;
using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
{
    public class MarketCapThermocapRatioEventDetectorService : IDataProcessorService<IMarketCapThermocapRatio>
    {
        public Task<bool> DetectEventAsync(IMarketCapThermocapRatio data)
        {
            return Task.Run(() => data.Value >= 0.75);
        }
    }
}
