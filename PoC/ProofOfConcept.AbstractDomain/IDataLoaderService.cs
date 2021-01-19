using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataLoaderService<T> where T : Entity
    {
        Task<T> LoadDataAsync();
    }
}
