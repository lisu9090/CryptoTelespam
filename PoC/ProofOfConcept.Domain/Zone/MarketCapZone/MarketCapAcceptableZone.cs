using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.MarketCapZone
{
    public class MarketCapAcceptableZone : IndicatorZone<MarketCapThermocapRatio>
    {
        internal class ZoneRange : IZoneRange<MarketCapAcceptableZone, MarketCapThermocapRatio, float>
        {
            private readonly Range _range = Range.And(x => x >= double.MinValue, x => x <= 0.000003f);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Acceptable";
    }
}