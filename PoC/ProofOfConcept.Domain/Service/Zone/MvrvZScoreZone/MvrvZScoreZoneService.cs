using ProofOfConcept.Domain.Enum;
using ProofOfConcept.Domain.Service.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Service.Zone.MvrvZScoreZone
{
    public class MvrvZScoreZoneService : IZoneSelector
    {
        private readonly IEnumerable<IZoneSelector> _LthNuplZones;

        public MvrvZScoreZoneService()
        {
            _LthNuplZones = new List<IZoneSelector>
            {
                new MvrvZScoreBeliefSelector(),
                new MvrvZScoreCapitulationSelector(),
                new MvrvZScoreEuphoriaSelector(),
                new MvrvZScoreHopeSelector(),
                new MvrvZScoreOptimismSelector()
            };
        }

        public ZoneId? SelectZone(double value) => _LthNuplZones
            .Select(zoneSelector => zoneSelector.SelectZone(value))
            .Where(zoneId => zoneId.HasValue)
            .FirstOrDefault();
    }
}