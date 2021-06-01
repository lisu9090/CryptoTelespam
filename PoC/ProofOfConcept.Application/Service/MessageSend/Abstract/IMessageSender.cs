using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend.Abstract
{
    public interface IMessageSender<TValue>
    {
        Task SendEventMessageAsync(ZoneChangeEvent<TValue> zoneChangeEvent);

        Task SendNotificationAsync(IndicatorValueCollection<TValue> indicatorValues);
    }
}