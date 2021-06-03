using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.ZoneChange.Abstract
{
    public interface IZoneChangeDetector<TValue>
    {
        ZoneChangeEvent<TValue> DetectEvent(IndicatorValueCollection<TValue> indicatorValues);
    }
}