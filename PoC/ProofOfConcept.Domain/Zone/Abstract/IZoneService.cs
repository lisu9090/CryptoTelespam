using ProofOfConcept.Domain.Indicator.Abstract;
using System.Collections.Generic;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    public interface IZoneService<TIndicator, TValue>
        where TIndicator : CryptoIndicator<TValue>
    {
        IndicatorZone<TIndicator> GetZone(TValue value);
    }
}