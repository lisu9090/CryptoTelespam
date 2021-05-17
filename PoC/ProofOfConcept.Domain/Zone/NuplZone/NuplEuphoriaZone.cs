using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplEuphoriaZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplEuphoriaZone, Nupl, float>
        {
            private Range _range = Range.And(x => x >= 0.75f, x => x <= double.MaxValue);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Euphoria";
    }
}