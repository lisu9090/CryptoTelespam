using ProofOfConcept.AbstractDomain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.AbstractDomain
{
    public interface IMessageSenderService<T> where T : ICryptocurrencyIndicator
    {
        Task SendEventMessageAsync(T data);
    }
}
