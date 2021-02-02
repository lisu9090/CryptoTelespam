using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Domain
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        Task<StockEvent<T>> DetectEventAsync(T data);
    }
}
