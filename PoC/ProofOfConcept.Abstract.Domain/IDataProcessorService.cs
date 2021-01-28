using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        Task<bool> DetectEventAsync(T data);
    }
}
