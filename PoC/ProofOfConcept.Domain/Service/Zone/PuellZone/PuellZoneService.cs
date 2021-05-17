using ProofOfConcept.Domain.IndicatorTmp;
using ProofOfConcept.Domain.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Zone.PuellZone
{
    public class PuellZoneService
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<Puell>, Puell, float>> _zoneRanges;

        public PuellZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<Puell>, Puell, float>>
            {
                new PuellBeliefZone.ZoneRange(),
                new PuellCapitulationZone.ZoneRange(),
                new PuellEuphoriaZone.ZoneRange(),
                new PuellHopeZone.ZoneRange(),
                new PuellOptimismZone.ZoneRange()
            };
        }

        public IndicatorZone<Puell> GetZone(float value)
        {
            IZoneRange<IndicatorZone<Puell>, Puell, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}