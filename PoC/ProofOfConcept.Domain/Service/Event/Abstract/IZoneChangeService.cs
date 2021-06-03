using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Domain.Event.Abstract
{
    public interface IZoneChangeService
    {
        MessageTemplateId? GetMessageTemplateId(ZoneId currentZoneId, ZoneId previousZoneId);
    }
}