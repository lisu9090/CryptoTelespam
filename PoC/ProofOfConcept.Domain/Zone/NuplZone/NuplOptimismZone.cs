using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplOptimismZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplOptimismZone, Nupl, float>
        {
            private Range _range = Range.And(x => x >= 0.25f, x => x < 0.5f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Optimism";
    }
}