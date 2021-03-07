using ProofOfConcept.Abstract.Domain.Model;
using ProofOfConcept.Abstract.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Domain.Domain.DataProcess
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
