using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.MarketCapZone
{
    public class MarketCapHopeZone : IndicatorZone<MarketCapThermocapRatio>
    {
        internal class ZoneRange : IZoneRange<MarketCapHopeZone, MarketCapThermocapRatio, float>
        {
            private Range _range = Range.And(x => x >= 0.00000004f, x => x < 0.0000001f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Hope";
    }
}