using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Application.Service.DataProcess.Abstract
{
    public interface IDataProcessorFactory<TValue>
    {
        IDataProcessor<TValue> GetDataProcessor(IndicatorId indicatorId);
    }
}