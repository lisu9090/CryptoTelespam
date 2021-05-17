using ProofOfConcept.Domain.Entity;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;

namespace ProofOfConcept.Domain.Event.Abstract
{
    public abstract class StockEvent<TIndicator> where TIndicator : CryptoIndicatorBase
    {
        public TIndicator Indicator { get; set; }

        public int StockEventMessageTemplateId { get; set; }

        public virtual MessageTemplate StockEventMessageTemplate { get; set; }
    }
}