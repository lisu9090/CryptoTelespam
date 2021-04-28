using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellBuyZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellBuyZone, Puell, float>
        {
            private readonly Range _range = Range.And(x => x >= 0.3f, x => x <= 0.5f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Buy";
    }
}