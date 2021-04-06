using ProofOfConcept.Domain;

namespace ProofOfConcept.Abstract.Application
{
    public interface IDataProcessorService<T> where T : CryptocurrencyIndicator
    {
        StockEvent<T> DetectEvent(T data);
    }
}