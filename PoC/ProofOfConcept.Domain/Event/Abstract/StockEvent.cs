using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Domain.Event.Abstract
{
    public abstract class StockEvent<T> where T : CryptocurrencyIndicator
    {
        public T Indicator { get; set; }

        public int MessageTemplateId { get; set; }
    }
}