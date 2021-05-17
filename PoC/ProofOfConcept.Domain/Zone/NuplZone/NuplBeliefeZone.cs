using ProofOfConcept.Common;
using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplBeliefeZone : IndicatorZone<Nupl>
    {
        internal class ZoneRange : IZoneRange<NuplBeliefeZone, Nupl, float>
        {
            private readonly Range _range = Range.And(x => x >= 0, x => x < 0.25f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Beliefe";
    }
}