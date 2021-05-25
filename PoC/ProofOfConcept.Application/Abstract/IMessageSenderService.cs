using ProofOfConcept.Domain.ValueObject;
using System.Threading.Tasks;

namespace ProofOfConcept.Abstract.Application
{
    public interface IMessageSenderService
    {
        Task SendEventMessageAsync(ZoneChangeEvent<float> zoneChangeEvent);

        Task SendNotificationAsync(IndicatorValueCollection<float> indicatorValues);
    }
}