using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IMessageSenderService<T> where T : CryptoIndicatorBase
    {
        Task SendEventMessageAsync(ZoneChageEvent<T> data);

        Task SendNotificationAsync(T notification);
    }
}