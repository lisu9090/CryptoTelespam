using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellSellZone : IndicatorZone<Puell>
    {
        internal class ZoneRange : IZoneRange<PuellSellZone, Puell, float>
        {
            private readonly Range _range = Range.And(x => x >= 4f, x => x <= 10f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Sell";
    }
}