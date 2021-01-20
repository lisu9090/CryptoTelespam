using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IMessageSenderService<T>
    {
        Task SendEventMessageAsync(T data);
    }
}
