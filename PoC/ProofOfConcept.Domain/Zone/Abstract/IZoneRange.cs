﻿using ProofOfConcept.Domain.Indicator.Abstract;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    internal interface IZoneRange<in TZone, TIndicator, TValue>
        where TZone : IndicatorZone<TIndicator> //TODO consider new()
        where TIndicator : CryptoIndicator<TValue>
    {
        bool IsInZone(TValue value);
    }
}