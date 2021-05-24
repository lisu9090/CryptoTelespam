using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.LthNuplZone
{
    public class LthNuplZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public LthNuplZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new LthNuplBeliefeZone(),
                new LthNuplCapitulationZone(),
                new LthNuplEuphoriaZone(),
                new LthNuplHopeZone(),
                new LthNuplOptimismZone()
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}