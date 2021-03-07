using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Domain
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        StockEvent<T> DetectEvent(T data);
    }
}
