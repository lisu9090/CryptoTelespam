using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataLoaderService<T>
    {
        Task<T> LoadDataAsync();
    }
}
