using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplHopeZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplHopeZone, Nupl, float>
        {
            private Range _range = Range.And(x => x >= 0.5f, x => x < 0.75f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Hope";
    }
}