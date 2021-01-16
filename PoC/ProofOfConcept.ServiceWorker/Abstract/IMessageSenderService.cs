using System.Threading.Tasks;

namespace ProofOfConcept.ServiceWorker.Abstract
{
    interface IMessageSenderService<T>
    {
        Task SendEventMessageAsync(T data);
    }
}
