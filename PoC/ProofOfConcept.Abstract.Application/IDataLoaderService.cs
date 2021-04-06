using ProofOfConcept.Domain;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataLoaderService<T> where T : CryptocurrencyIndicator
    {
        Task<T> LoadDataAsync(string cryptocurrencySymbol);
    }
}