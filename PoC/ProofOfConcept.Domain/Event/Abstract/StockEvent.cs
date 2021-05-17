using ProofOfConcept.Domain.Entity;
using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Domain.Event.Abstract
{
    public abstract class StockEvent<TIndicator> where TIndicator : CryptoIndicatorBase
    {
        public TIndicator Indicator { get; set; }

        public int StockEventMessageTemplateId { get; set; }

        public virtual StockEventMessageTemplate StockEventMessageTemplate { get; set; }
    }
}