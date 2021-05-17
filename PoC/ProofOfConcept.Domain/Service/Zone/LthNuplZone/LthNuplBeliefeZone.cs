using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplBeliefeZone : IndicatorZone<LthNupl>
    {
        internal class ZoneRange : IZoneRange<LthNuplBeliefeZone, LthNupl, float>
        {
            private readonly Range _range = Range.And(x => x >= 0, x => x < 0.25f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Beliefe";
    }
}