using ProofOfConcept.Abstract.Application.Model;
using ProofOfConcept.Abstract.Application;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Domain.DataProcess
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
