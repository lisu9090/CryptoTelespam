using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Application.Service.DataLoad.Abstract
{
    public interface IIndicatorValueLoaderFactory<TValue>
    {
        IIndicatorValueLoader<TValue> GetLoader(IndicatorId indicatorId);
    }
}