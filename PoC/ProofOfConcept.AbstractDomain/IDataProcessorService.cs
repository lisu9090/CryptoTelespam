using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IDataProcessorService<T>
    {
        Task<bool> DetectEventAsync(T data);
    }
}
