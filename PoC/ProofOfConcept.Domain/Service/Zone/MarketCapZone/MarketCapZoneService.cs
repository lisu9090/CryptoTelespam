using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.MarketCapZone
{
    public class MarketCapZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public MarketCapZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new MarketCapBeliefSelector(),
                new MarketCapCapitulationSelector(),
                new MarketCapEuphoriaSelector(),
                new MarketCapHopeSelector(),
                new MarketCapOptimismSelector()
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}