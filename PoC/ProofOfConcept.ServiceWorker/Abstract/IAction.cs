using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IAction
    {
        Task ExecuteAsync();
    }
}
