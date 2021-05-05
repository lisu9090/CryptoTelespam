using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Indicator.Abstract;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataLoaderService<T> where T : CryptoIndicatorBase
    {
        Task<T> LoadDataAsync(int assetId);
    }
}