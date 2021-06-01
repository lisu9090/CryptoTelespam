using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Application.Service.MessageSend.Abstract
{
    public interface IMessageSenderFactory<TValue>
    {
        IMessageSender<TValue> GetMessageSender(IndicatorId indicatorId);
    }
}