using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplOptimismZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplOptimismZone, Nupl, float>
        {
            private Range _range = Range.And(x => x >= 0.25f, x => x < 0.5f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Optimism";
    }
}