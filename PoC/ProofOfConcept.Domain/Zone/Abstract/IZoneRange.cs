using ProofOfConcept.Domain.IndicatorTmp.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    internal interface IZoneRange<out TZone, TIndicator, TValue>
        where TZone : IndicatorZone<TIndicator> //TODO consider new()
        where TIndicator : CryptoIndicator<TValue>
    {
        bool IsInZone(TValue value);
    }
}