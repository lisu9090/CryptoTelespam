using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IDataLoaderService<T>
    {
        Task<T> LoadDataAsync();
    }
}
