using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.NuplZone
{
    public class NuplZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public NuplZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new NuplBeliefeSelector(),
                new NuplCapitulationSelector(),
                new NuplEuphoriaSelector(),
                new NuplHopeSelector(),
                new NuplOptimismSelector()
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}