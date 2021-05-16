using ProofOfConcept.Domain.Indicator;
using ProofOfConcept.Domain.Zone.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProofOfConcept.Domain.Zone.MvrvZScoreZone
{
    public class MvrvZScoreZoneService
    {
        private readonly IEnumerable<IZoneRange<IndicatorZone<MvrvZScore>, MvrvZScore, float>> _zoneRanges;

        public MvrvZScoreZoneService()
        {
            _zoneRanges = new List<IZoneRange<IndicatorZone<MvrvZScore>, MvrvZScore, float>>
            {
                new MvrvZScoreCapitulationZone.ZoneRange(),
                new MvrvZScoreEuphoriaZone.ZoneRange(),
                new MvrvZScoreHopeZone.ZoneRange(),
                new MvrvZScoreOptimismZone.ZoneRange(),
                new MvrvZScoreBeliefZone.ZoneRange()
            };
        }

        public IndicatorZone<MvrvZScore> GetZone(float value)
        {
            IZoneRange<IndicatorZone<MvrvZScore>, MvrvZScore, float> zoneRange = _zoneRanges
                .Where(range => range.IsInZone(value))
                .FirstOrDefault();

            return new IndicatorZoneActivator()
                .CreateZoneInstance(zoneRange);
        }
    }
}