using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IDataProcessorService<T>
    {
        Task<bool> DetectEventAsync(T data);
    }
}
