using ProofOfConcept.Domain;
using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService<T> where T : CryptoIndicatorBase
    {
        ZoneChageEvent<T> DetectEvent(T data);
    }
}