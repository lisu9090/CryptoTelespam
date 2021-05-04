using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProofOfConcept.Domain.Zone.NuplZone
{
    public class NuplZoneService : IZoneService<Nupl, float>
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<Nupl>, Nupl, float>> _zoneRanges;

        public NuplZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<Nupl>, Nupl, float>>
            {
                new NuplBeliefeZone.ZoneRange(),
                new NuplCapitulationZone.ZoneRange(),
                new NuplEuphoriaZone.ZoneRange(),
                new NuplHopeZone.ZoneRange(),
                new NuplOptimismZone.ZoneRange()
            };
        }

        public IndicatorZone<Nupl> GetZone(float value)
        {
            IZoneRange<IndicatorZone<Nupl>, Nupl, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}