using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.MvrvZScoreZone
{
    public class MvrvZScoreHopeZone : IndicatorZone<MvrvZScore>
    {
        internal class ZoneRange : IZoneRange<MvrvZScoreHopeZone, MvrvZScore, float>
        {
            private Range _range = Range.And(x => x >= 0.0f, x => x < 2.5f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Hope";
    }
}