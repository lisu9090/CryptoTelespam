using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.MarketCapZone
{
    public class MarketCapOptimismZone : IndicatorZone<MarketCapThermocapRatio>
    {
        internal class ZoneRange : IZoneRange<MarketCapOptimismZone, MarketCapThermocapRatio, float>
        {
            private Range _range = Range.And(x => x >= 0.0000001f, x => x < 0.00000025f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Optimism";
    }
}