using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataProcessorService<T> where T : Entity
    {
        Task<bool> DetectEventAsync(T data);
    }
}
