using ProofOfConcept.Abstract.Domain.Model;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Domain
{
    public interface IMessageSenderService<T> where T : CryptocurrencyIndicator
    {
        Task SendEventMessageAsync(T data);
    }
}
