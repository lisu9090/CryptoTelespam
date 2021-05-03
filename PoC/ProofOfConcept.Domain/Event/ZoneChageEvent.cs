using ProofOfConcept.Domain.Event.Abstract;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain
{
    public class ZoneChageEvent<TIndicator> : StockEvent<TIndicator>
        where TIndicator : CryptoIndicatorBase
    {
        public IndicatorZone<TIndicator> CurrentZone { get; set; }

        public IndicatorZone<TIndicator> PreviousZone { get; set; }
    }
}