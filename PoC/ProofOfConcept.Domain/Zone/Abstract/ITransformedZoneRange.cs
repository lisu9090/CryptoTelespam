using ProofOfConcept.Domain.IndicatorTmp.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    internal interface ITransformedZoneRange<in TZone, TIndicator, TValue>
        where TZone : IndicatorZone<TIndicator> //TODO consider new()
        where TIndicator : CryptoIndicatorBase
    {
        bool IsInZone(TIndicator indicator);
    }
}