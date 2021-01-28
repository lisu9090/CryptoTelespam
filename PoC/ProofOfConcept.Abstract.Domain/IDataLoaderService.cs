using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataLoaderService<T> where T : CryptocurrencyIndicator
    {
        Task<T> LoadDataAsync(string cryptocurrencySymbol);
    }
}
