using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Zone.LthNuplZone
{
    public class LthNuplZoneService
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<LthNupl>, LthNupl, float>> _zoneRanges;

        public LthNuplZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<LthNupl>, LthNupl, float>>
            {
                new LthNuplBeliefeZone.ZoneRange(),
                new LthNuplCapitulationZone.ZoneRange(),
                new LthNuplEuphoriaZone.ZoneRange(),
                new LthNuplHopeZone.ZoneRange(),
                new LthNuplOptimismZone.ZoneRange()
            };
        }

        public IndicatorZone<LthNupl> GetZone(float value)
        {
            IZoneRange<IndicatorZone<LthNupl>, LthNupl, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}