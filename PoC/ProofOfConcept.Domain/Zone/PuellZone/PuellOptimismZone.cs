using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellOptimismZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellOptimismZone, Puell, float>
        {
            private Range _range = Range.And(x => x >= 1.5f, x => x < 3.0f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Optimism";
    }
}