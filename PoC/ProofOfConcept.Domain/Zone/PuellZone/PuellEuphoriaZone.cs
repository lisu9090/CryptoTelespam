using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellEuphoriaZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellEuphoriaZone, Puell, float>
        {
            private Range _range = Range.And(x => x >= 4.0f, x => x <= double.MaxValue);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Euphoria";
    }
}