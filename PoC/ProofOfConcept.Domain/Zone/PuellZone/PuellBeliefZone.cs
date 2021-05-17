using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellBeliefZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellBeliefZone, Puell, float>
        {
            private Range _range = Range.And(x => x >= 3.0f, x => x < 4.0f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Beliefe";
    }
}