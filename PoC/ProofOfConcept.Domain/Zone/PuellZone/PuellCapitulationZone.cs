using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellCapitulationZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellCapitulationZone, Puell, float>
        {
        private Range _range = Range.And(x => x >= double.MinValue, x => x < 0.5f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Capitulation";
    }
}