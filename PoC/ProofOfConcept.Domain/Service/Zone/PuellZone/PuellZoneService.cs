using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.PuellZone
{
    public class PuellZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public PuellZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new PuellBeliefSelector(),
                new PuellCapitulationSelector(),
                new PuellEuphoriaSelector(),
                new PuellHopeSelector(),
                new PuellOptimismSelector()
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}