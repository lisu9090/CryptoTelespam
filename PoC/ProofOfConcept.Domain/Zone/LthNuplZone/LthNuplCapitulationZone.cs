using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplCapitulationZone : IndicatorZone<LthNupl>
    {
        internal class ZoneRange : IZoneRange<LthNuplCapitulationZone, LthNupl, float>
        {
            private Range _range = Range.And(x => x >= double.MinValue, x => x < 0);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Capitulation";
    }
}