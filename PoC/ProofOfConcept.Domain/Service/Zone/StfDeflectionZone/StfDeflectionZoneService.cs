using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.StfDeflectionZone
{
    public class StfDeflectionZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public StfDeflectionZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new StfDeflectionAcceptableSelector(),
                new StfDeflectionUnacceptableSelector(),
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}