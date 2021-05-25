using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService
    {
        ZoneChangeEvent<float> DetectEvent(IndicatorValueCollection<float> indicatorValues);
    }
}