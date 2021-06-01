using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.DataProcess.Abstract
{
    public interface IDataProcessor<TValue>
    {
        ZoneChangeEvent<TValue> DetectEvent(IndicatorValueCollection<TValue> indicatorValues);
    }
}