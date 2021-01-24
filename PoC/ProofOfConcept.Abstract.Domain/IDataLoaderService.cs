using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataLoaderService<T> where T : ICryptocurrencyIndicator
    {
        Task<T> LoadDataAsync(string cryptocurrencySymbol);
    }
}
