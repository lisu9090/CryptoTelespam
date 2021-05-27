using ProofOfConcept.Domain.ValueObject;

namespace ProofOfConcept.Application.Service.DataProcess.Abstract
{
    public interface IDataProcessorService
    {
        ZoneChangeEvent<float> DetectEvent(IndicatorValueCollection<float> indicatorValues);
    }
}