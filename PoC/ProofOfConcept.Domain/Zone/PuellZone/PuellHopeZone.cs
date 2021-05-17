using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellHopeZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellHopeZone, Puell, float>
        {
            private Range _range = Range.And(x => x >= 0.5f, x => x < 1.5f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Hope";
    }
}