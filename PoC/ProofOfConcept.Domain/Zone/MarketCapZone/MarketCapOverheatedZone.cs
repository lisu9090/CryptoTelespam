using ProofOfConcept.Common;
using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;

namespace ProofOfConcept.Domain.Zone.MarketCapZone
{
    public class MarketCapOverheatedZone : IndicatorZone<MarketCapThermocapRatio>
    {
        internal class ZoneRange : IZoneRange<MarketCapOverheatedZone, MarketCapThermocapRatio, float>
        {
            private readonly Range _range = Range.And(x => x > 0.000004f, x => x <= double.MaxValue);

            public bool IsInZone(float value) => _range.IsInRange(value);
        }

        public override string Name => "Overheated";
    }
}