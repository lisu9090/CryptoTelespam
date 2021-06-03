using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Service.ZoneChange.Abstract;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.ZoneChange
{
    public class NewAddressesEventDetectorService : IZoneChangeDetector<int>
    {
        public ZoneChangeEvent<int> DetectEvent(IndicatorValueCollection<int> indicatorValues)
        {
            //TODO
            //val is greater than 160k
            //algorytm normalizujacy dane
            //wykrywanie najwiekszych peakow

            throw new System.NotImplementedException();
        }
    }
}