using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    public abstract class IndicatorZone<TIndicator, TValue> where TIndicator : CryptocurrencyIndicator<TValue>
    {
        public abstract string Name { get; }

        public abstract bool IsInZone(IndicatorValue<TValue> value);
    }
}