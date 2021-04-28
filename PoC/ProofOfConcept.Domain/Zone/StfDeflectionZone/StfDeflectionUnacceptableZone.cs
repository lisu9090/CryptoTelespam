using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.StfDeflectionZone
{
    public class StfDeflectionUnacceptableZone : IndicatorZone<StfDeflection>
    {
        internal class ZoneRange : IZoneRange<StfDeflectionUnacceptableZone, StfDeflection, float>
        {
            private readonly Range _range = Range.And(x => x > 0, x => x <= double.MaxValue);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Unacceptable";
    }
}