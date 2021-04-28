using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplBeliefeZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplBeliefeZone, Nupl, float>
        {
            private readonly Range _range = Range.And(x => x >= 0, x => x < 0.25f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Beliefe";
    }
}