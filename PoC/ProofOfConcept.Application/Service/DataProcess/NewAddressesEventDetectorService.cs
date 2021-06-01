using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Application.Service.DataProcess.Abstract;
using ProofOfConcept.Domain;
using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class NewAddressesEventDetectorService : IDataProcessor<int>
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