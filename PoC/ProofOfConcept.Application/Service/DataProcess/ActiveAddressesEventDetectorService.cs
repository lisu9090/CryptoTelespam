using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class ActiveAddressesEventDetectorService : IDataProcessor<int>
    {
        public ZoneChangeEvent<int> DetectEvent(IndicatorValueCollection<int> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}