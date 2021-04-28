using ProofOfConcept.Domain.Indicator.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfConcept.Domain.Zone.Abstract
{
    internal interface IZoneRange<in TZone, TIndicator, TValue>
        where TZone : IndicatorZone<TIndicator> //, new()
        where TIndicator : CryptocurrencyIndicator<TValue>
    {
        bool IsInZone(TValue value);
    }
}