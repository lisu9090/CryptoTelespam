using ProofOfConcept.Abstract.Application;
using ProofOfConcept.Domain;

namespace ProofOfConcept.Application.Service.DataProcess
{
    public class NewAddressesEventDetectorService : IDataProcessorService<NewAddresses>
    {
        public StockEvent<NewAddresses> DetectEvent(NewAddresses data)
        {
            return null; //todo

            //val is greater than 160k
            //algorytm normalizujacy dane
            //wykrywanie najwiekszych peakow
        }
    }
}