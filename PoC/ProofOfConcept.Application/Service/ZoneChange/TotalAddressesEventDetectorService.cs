using ProofOfConcept.Application.Service.ZoneChange.Abstract;
using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.ZoneChange
{
    public class TotalAddressesEventDetectorService : IZoneChangeDetector<int>
    {
        public ZoneChangeEvent<int> DetectEvent(IndicatorValueCollection<int> indicatorValues)
        {
            throw new System.NotImplementedException();
        }
    }
}