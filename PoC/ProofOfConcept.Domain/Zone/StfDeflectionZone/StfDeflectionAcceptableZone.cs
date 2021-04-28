using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.StfDeflectionZone
{
    public class StfDeflectionAcceptableZone : IndicatorZone<StfDeflection>
    {
        internal class ZoneRange : IZoneRange<StfDeflectionAcceptableZone, StfDeflection, float>
        {
            private readonly Range _range = Range.And(x => x >= double.MinValue, x => x <= 0);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Acceptable";
    }
}