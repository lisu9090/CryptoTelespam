using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplHopeZone : IndicatorZone<LthNupl>
    {
        internal class ZoneRange : IZoneRange<LthNuplHopeZone, LthNupl, float>
        {
            private Range _range = Range.And(x => x >= 0.5f, x => x < 0.75f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Hope";
    }
}