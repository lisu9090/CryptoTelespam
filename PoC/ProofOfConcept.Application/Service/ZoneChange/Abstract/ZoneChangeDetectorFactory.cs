using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Application.Service.ZoneChange.Abstract
{
    public interface ZoneChangeDetectorFactory<TValue>
    {
        IZoneChangeDetector<TValue> GetDataProcessor(IndicatorId indicatorId);
    }
}