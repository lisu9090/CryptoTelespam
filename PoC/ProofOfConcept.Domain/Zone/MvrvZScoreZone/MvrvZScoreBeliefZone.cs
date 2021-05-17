using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.IndicatorTmp.Abstract;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using ProofOfConcept.Common;

namespace ProofOfConcept.Domain.Zone.MvrvZScoreZone
{
    public class MvrvZScoreBeliefZone : IndicatorZone<MvrvZScore>
    {
        internal class ZoneRange : IZoneRange<MvrvZScoreBeliefZone, MvrvZScore, float>
        {
            private Range _range = Range.And(x => x >= 4.5f, x => x < 7.0f);
            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Beliefe";
    }
}