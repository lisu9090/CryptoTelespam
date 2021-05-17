using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplOptimismZone : IndicatorZone<LthNupl>
    {
        internal class ZoneRange : IZoneRange<LthNuplOptimismZone, LthNupl, float>
        {
            private Range _range = Range.And(x => x >= 0.25f, x => x < 0.5f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Optimism";
    }
}