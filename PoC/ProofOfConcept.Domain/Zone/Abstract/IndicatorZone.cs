using ProofOfConcept.Domain.IndicatorTmp.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    public abstract class IndicatorZone<TIndicator> where TIndicator : CryptoIndicatorBase
    {
        public abstract string Name { get; }
    }
}