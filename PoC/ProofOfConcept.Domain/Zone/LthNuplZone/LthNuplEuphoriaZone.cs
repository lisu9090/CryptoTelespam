using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplEuphoriaZone : IndicatorZone<LthNupl>
    {
        internal class ZoneRange : IZoneRange<LthNuplEuphoriaZone, LthNupl, float>
        {
            private Range _range = Range.And(x => x >= 0.75f, x => x <= double.MaxValue);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Euphoria";
    }
}