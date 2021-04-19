using ProofOfConcept.Domain;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        ZoneChageEvent<T> DetectEvent(T data);
    }
}