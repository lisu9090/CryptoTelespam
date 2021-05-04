using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Zone.MarketCapZone
{
    public class MarketCapZoneService
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<MarketCapThermocapRatio>, MarketCapThermocapRatio, float>> _zoneRanges;

        public MarketCapZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<MarketCapThermocapRatio>, MarketCapThermocapRatio, float>>
            {
                new MarketCapAcceptableZone.ZoneRange(),
                new MarketCapCloseToOverheatZone.ZoneRange(),
                new MarketCapOverheatedZone.ZoneRange()
            };
        }

        public IndicatorZone<MarketCapThermocapRatio> GetZone(float value)
        {
            IZoneRange<IndicatorZone<MarketCapThermocapRatio>, MarketCapThermocapRatio, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}