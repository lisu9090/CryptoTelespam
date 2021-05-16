using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Indicator.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.MvrvZScoreZone
{
    public class MvrvZScoreEuphoriaZone : IndicatorZone<MvrvZScore>
    {
        internal class ZoneRange : IZoneRange<MvrvZScoreEuphoriaZone, MvrvZScore, float>
        {
            private Range _range = Range.And(x => x >= 7.0f, x => x <= double.MaxValue);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Euphoria";
    }
}