using ProofOfConcept.Abstract.Application.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        StockEvent<T> DetectEvent(T data);
    }
}
