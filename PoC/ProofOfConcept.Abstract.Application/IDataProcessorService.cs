using ProofOfConcept.Domain;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService<T> where T : CryptoIndicatorBase
    {
        ZoneChageEvent<T> DetectEvent(T data);
    }
}