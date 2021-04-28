using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    public abstract class IndicatorZone<TIndicator> where TIndicator : IndicatorBase
    {
        public abstract string Name { get; }
    }
}