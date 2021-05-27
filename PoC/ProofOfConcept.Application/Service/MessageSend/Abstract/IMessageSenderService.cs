using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Application.Service.MessageSend.Abstract
{
    public interface IMessageSenderService
    {
        Task SendEventMessageAsync(ZoneChangeEvent<float> zoneChangeEvent);

        Task SendNotificationAsync(IndicatorValueCollection<float> indicatorValues);
    }
}